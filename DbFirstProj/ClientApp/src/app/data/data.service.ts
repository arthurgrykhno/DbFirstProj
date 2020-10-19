import { from } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Relation } from './data.relation';

@Injectable()
export class DataService {

  private url = "/api/home";

  constructor(private http: HttpClient) { }

  getRelations() {
    return this.http.get(this.url + '/' + 'relations');
  }

  deleteRelation(r: string) {
    return this.http.delete(this.url + '/' + r);
  }

  getRelation(r: string) {
    return this.http.get(this.url + '/' + r);
  }

  
}
