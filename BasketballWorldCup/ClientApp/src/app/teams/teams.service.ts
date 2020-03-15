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
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl);
  }

  getTeamsByTier(tier: number) {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl + '/' + tier);
  }
}

export interface Team{
  id: number;
  name: string;
  tier: number;
}
