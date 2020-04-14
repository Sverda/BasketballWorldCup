import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({ providedIn: "root" })
export class ZonesService {
  baseUrl: string;
  zonesUrl = "api/zones";

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getZones() {
    return this.http.get<string[]>(this.baseUrl + this.zonesUrl);
  }
}
