import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HarmonyServiceService {

  private baseUrl = "http://localhost:20355/api/Harmony/";

  constructor(private http: HttpClient) { }

getData(){
  var url =this.baseUrl ;//+ 'getdata'
  return this.http.get(url);
}

}
