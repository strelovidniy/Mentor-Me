import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Proposition from '../types/proposition';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class PropositionService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public getRequests(): Promise<Proposition[]> {
        return this.http.get<Proposition[]>(`${this.endpointService.propositionsUrl}requests`).toPromise();
    }

    public getOffers(): Promise<Proposition[]> {
        return this.http.get<Proposition[]>(`${this.endpointService.propositionsUrl}offers`).toPromise();
    }

    public creteProposition(proposition: Proposition): Promise<Proposition> {
        return this.http.post<Proposition>(`${this.endpointService.propositionsUrl}`, proposition).toPromise();
    }

    public getProposition(propositionId: string): Promise<Proposition> {
        return this.http.get<Proposition>(`${this.endpointService.propositionsUrl}${propositionId}`).toPromise();
    }
}
