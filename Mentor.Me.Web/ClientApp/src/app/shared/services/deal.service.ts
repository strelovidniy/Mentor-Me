import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Deal from '../types/deal';
import EndpointService from './endpoint.service';

@Injectable({
    providedIn: 'root'
})
export default class DealService {

    public constructor(
        private endpointService: EndpointService,
        private http: HttpClient
    ) { }

    public getUserDeals(userId: string): Promise<Deal[]> {
        return this.http.get<Deal[]>(`${this.endpointService.dealsUrl}by-user/${userId}`).toPromise();
    }

    public getDeal(dealId: string): Promise<Deal> {
        return this.http.get<Deal>(`${this.endpointService.dealsUrl}${dealId}`).toPromise();
    }
}
