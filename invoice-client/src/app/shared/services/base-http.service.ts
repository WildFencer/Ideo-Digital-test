import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BaseHttpService {

  public readonly _baseUrl = "http://localhost:3000/api";

  constructor() { }

  public getOptions(contentType: string = 'application/json'): { headers: HttpHeaders } {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', contentType);
    // Added these headers to prevent caching of GET requests for Internet Explorer
    headers = headers.append('Cache-Control', 'no-cache');
    headers = headers.append('Pragma', 'no-cache');
    headers = headers.append('Expires', 'Sat, 01 Jan 2000 00: 00: 00 GMT');
    return { headers: headers };
}

}
