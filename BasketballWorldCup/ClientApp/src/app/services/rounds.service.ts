import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { GroupResult } from "../model/group-result.interface";

@Injectable({ providedIn: "root" })
export class RoundsService {
  private readonly baseUrl: string;
  private firstRoundUrl = "api/competition/firstRound";
  private secondRoundUrl = "api/competition/secondRound";
  private finalRoundUrl = "api/competition/finalRound";

  constructor(
    private readonly http: HttpClient,
    @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getFirstRound(drawId: number): Observable<GroupResult[]> {
    return this.http.get<GroupResult[]>(this.baseUrl + this.firstRoundUrl + "/" + drawId);
  }

  getSecondRound(drawId: number): Observable<GroupResult[]> {
    return this.http.get<GroupResult[]>(this.baseUrl + this.secondRoundUrl + "/" + drawId);
  }

  getFinalRound(drawId: number): Observable<GroupResult[]> {
    return this.http.get<GroupResult[]>(this.baseUrl + this.finalRoundUrl + "/" + drawId);
  }
}
