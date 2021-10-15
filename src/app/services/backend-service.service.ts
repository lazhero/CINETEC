import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { HttpParams } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class BackendService {
  constructor(private http: HttpClient) {}

  serverIp: string = 'http://25.92.13.1:38389/';

  get_request(url: string, Params: any): Observable<any> {
    var http_params = new HttpParams({ fromObject: Params });

    return this.http.get(this.serverIp + url, { params: http_params });
  }
  post_request(url: string, Params: object) {
    return this.http.post(this.serverIp + url, Params);
  }
  put_request(url: string, Params: object) {
    return this.http.put(this.serverIp + url, Params);
  }

  delete_request(url: string, Params: object) {
    return this.http.delete(this.serverIp + url, Params);
  }
}
