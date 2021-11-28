import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import CreateMeetingModel from '../types/create-meeting-model';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class GoogleCalendarService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public scheduleMeeting(model: CreateMeetingModel): Promise<void> {
        return this.http.post<void>(`${this.endpointService.googleCalendarUrl}create`, model).toPromise();
    }
}
