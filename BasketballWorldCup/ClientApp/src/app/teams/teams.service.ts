import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({ providedIn: 'root'})
export class TeamsService {
  baseUrl: string;
  teamsUrl = 'api/teams';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getTeams() {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl);
  }

  getTeamsByTier(tier: number) {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl + '/' + tier);
  }

  addTeam(team: Team) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<Team>(this.baseUrl + this.teamsUrl, team, httpOptions);
  }
}

export interface Team{
  id: number;
  name: string;
  tier: number;
}
