import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject } from "rxjs";

@Injectable({ providedIn: 'root'})
export class TeamsService {
  baseUrl: string;
  teamsUrl = 'api/teams';
  public addedUserSubject: Subject<Team>;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.addedUserSubject = new Subject<Team>();
  }

  getTeams() {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl);
  }

  getTeamsByTier(tier: number) {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl + '/' + tier);
  }

  addTeam(team: Team) {
    this.addedUserSubject.next(team);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<Team>(this.baseUrl + this.teamsUrl, team, httpOptions);
  }

  deleteTeam(team: Team) {
    return this.http.delete<Team>(this.baseUrl + this.teamsUrl + '/' + team.id);
  }
}

export interface Team{
  id: number;
  name: string;
  tier: number;
}
