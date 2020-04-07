import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Subject, Observable } from "rxjs";
import { Team } from "../model/team.interface";

@Injectable({ providedIn: "root"})
export class TeamsService {
  baseUrl: string;
  teamsUrl = "api/teams";
  public addedUserSubject: Subject<Team>;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
    this.addedUserSubject = new Subject<Team>();
  }

  public getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl);
  }

  public getTeamsByTier(tier: number): Observable<Team[]> {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl + "/" + tier);
  }

  public getTeamsByZone(zone: number): Observable<Team[]> {
    return this.http.get<Team[]>(this.baseUrl + this.teamsUrl + "/zone/" + zone);
  }

  public addTeam(team: Team): Observable<Team> {
    this.addedUserSubject.next(team);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': "application/json"
      })
    };

    return this.http.post<Team>(this.baseUrl + this.teamsUrl, team, httpOptions);
  }

  public deleteTeam(teamId: number): Observable<Team> {
    return this.http.delete<Team>(this.baseUrl + this.teamsUrl + "/" + teamId);
  }
}
