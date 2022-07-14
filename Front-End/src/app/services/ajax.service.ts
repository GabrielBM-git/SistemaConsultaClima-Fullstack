//-------------------------------------------------------------------------------------------------

import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';

import { Observable } from 'rxjs';

//-------------------------------------------------------------------------------------------------

import { HttpClient } from '@angular/common/http';

//-------------------------------------------------------------------------------------------------

@Injectable({
  providedIn: 'root'
})

//-------------------------------------------------------------------------------------------------

export class AjaxService {

    //-----------------------------------------------------------------------------------------------
  
    baseUrl = `${environment.baseUrl}/api/Sistema/`;
  
    //-----------------------------------------------------------------------------------------------
  
    constructor(private http: HttpClient) { }
  
    //-----------------------------------------------------------------------------------------------
  
    get_Minimas(): Observable<any[]> {
  
      var url: string = 'PrevisaoClima_Minimas';
  
      //console.log(`${this.baseUrl}${url}`);
  
      return this.http.get<any[]>(`${this.baseUrl}${url}`);
  
    }
  
    //-----------------------------------------------------------------------------------------------
  
    get_Maximas(): Observable<any[]> {
  
      var url: string = 'PrevisaoClima_Maximas';
  
      //console.log(`${this.baseUrl}${url}`);
  
      return this.http.get<any[]>(`${this.baseUrl}${url}`);
  
    }
  
    //-----------------------------------------------------------------------------------------------
  
    get_Cidades(): Observable<any[]> {
  
      var url: string = 'PrevisaoClima_Cidades';
  
      // console.log(`${this.baseUrl}${url}`);
  
      return this.http.get<any[]>(`${this.baseUrl}${url}`);
  
    }
  
    //-----------------------------------------------------------------------------------------------
  
    post_7Dias(cidade: string) {
  
      var url: string = 'PrevisaoClima_7Dias';
  
      // console.log(`${this.baseUrl}${url}`);
  
      return this.http.get<any[]>(`${this.baseUrl}${url}/${cidade}`);
  
    }
  
    //-----------------------------------------------------------------------------------------------
  }
  
//---------------------------------------------------------------------------------------------------