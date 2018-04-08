import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStaveNote } from '../vexflow-component/vexflow-component';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class HarmonyServiceService {
  private baseUrl = 'http://localhost:65117/api/Harmony/';

  constructor(private http: HttpClient) {}

  getData(): Observable<Array<Object>> {
    const url = this.baseUrl + 'getdata';
    return this.http.get<Array<Object>>(url);
  }

  //   getData(): Observable<Array<IStaveNote>> {
  //     const url = this.baseUrl + 'getdata';
  //     return this.http.get<Array<IStaveNote>>(url);
  //   }
}
