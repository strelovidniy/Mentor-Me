using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Mentor.Me.Domain.Models;
using Mentor.Me.Domain.Services.Interfaces;

namespace Mentor.Me.Domain.Services.Implementations
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        //Todo: get calendarId from config
        const string CalendarId = "carrrson2207@gmail.com";

        public async Task CreateMeeting(CreateMeetingModel model, IGoogleAuthProvider googleAuthProvider,
            CancellationToken ct)
        {
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = await googleAuthProvider.GetCredentialAsync(cancellationToken: ct),
                ApplicationName = "MentorMe"
            });

            var request = FillRequestModel(model, service);
            //TODO: save event Id
            var response = await request.ExecuteAsync(ct);
        }

        private static EventsResource.InsertRequest FillRequestModel(CreateMeetingModel model, CalendarService service)
        {
            var request = service.Events.Insert(new Event
            {
                Summary = model.Summary,
                Description = model.Description,
                Start = new EventDateTime
                {
                    DateTime = model.StartAt,
                    TimeZone = "Europe/Kiev",
                },
                End = new EventDateTime
                {
                    DateTime = model.EndAt,
                    TimeZone = "Europe/Kiev",
                },
                Attendees = model.Emails.Select(x => new EventAttendee {Email = x}).ToList(),
                ConferenceData = new ConferenceData
                {
                    CreateRequest = new CreateConferenceRequest
                    {
                        ConferenceSolutionKey = new ConferenceSolutionKey
                        {
                            Type = "hangoutsMeet"
                        },
                        RequestId = GetRandomString(),
                    }
                }
            }, CalendarId);
            request.ConferenceDataVersion = 1;
            return request;
        }

        private static string GetRandomString(int length = 20)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}