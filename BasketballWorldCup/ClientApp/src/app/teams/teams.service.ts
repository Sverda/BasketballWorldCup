import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root'})
export class TeamsService {
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  baseUrl: string;
  teamsUrl = 'api/teams';

  getTeams() {
    console.log(this.baseUrl + this.teamsUrl);
    return this.http.get<ITeam[]>(this.baseUrl + this.teamsUrl);
  }
}

export interface ITeam{
  id: number;
  name: string;
  tier: number;
}
