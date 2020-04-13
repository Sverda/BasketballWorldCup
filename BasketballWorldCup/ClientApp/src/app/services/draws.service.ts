import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

import { Draw } from "../model/draw.interface";
import { Team } from "../model/team.interface";

@Injectable({ providedIn: "root" })
export class DrawsService {
  private readonly baseUrl: string;
  private drawsUrl = "api/draws";

  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  addDraw(teams: Team[]): Observable<Draw> {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': "application/json"
      })
    };

    return this.http.post<Draw>(this.baseUrl + this.drawsUrl, teams, httpOptions);
  }
}
