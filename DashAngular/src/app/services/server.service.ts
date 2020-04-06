import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders } from '@angular/common/http';
import {Observable} from 'rxjs';
import {ServerMessage} from '../shared/server-message';
import {Server} from '../shared/server';
import { catchError, map, tap } from 'rxjs/operators';
import {HttpRequest} from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ServerService {

  constructor(private _http: HttpClient) { 
    this.headers = new Headers({
      'Content-Type' : 'application/json',
      'Accept' : 'q=0.8;application/json;q=0.9'
    });

    
  }

  options: HttpRequest<number>;
  headers: Headers;

  getServers(): Observable<Server[]> {
    return this._http.get<Server[]>('http://localhost:62781/api/server').pipe(catchError(this.handleError));

  }

  handleError(error: any) {
     const errMsg = (error.message) ? error.message: error.status ? '${error.status} - ${error.statusText}' : 'Server error';
      console.log(errMsg);
      return Observable.throw(errMsg);
    }
    

  
}
