import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export default class EndpointService {
    public readonly chatUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/chats/`;
    public readonly adminUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/admin/`;
    public readonly accountUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/account/`;
    public readonly goalsUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/goals/`;
    public readonly propositionsUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/propositions/`;
    public readonly dealsUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/deals/`;
    public readonly googleCalendarUrl = `${location.origin.includes('localhost') ? 'https://localhost:7024/' : ''}api/v1/calendar/`;
}
