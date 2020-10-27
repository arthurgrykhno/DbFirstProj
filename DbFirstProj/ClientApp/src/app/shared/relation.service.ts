import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RelationService {

  constructor(private http: HttpClient) { }


  postRelation(formData) {
    return this.http.post(environment.apiBaseURI + '/add', formData);
  }

  getRelations() {
    return this.http.get(environment.apiBaseURI + '/relations');
  }

  putRelation(formData) {
    return this.http.put(environment.apiBaseURI, formData);
  }

  deleteRelation(id) {
    return this.http.delete(environment.apiBaseURI + '/' + id);
  }

  deleteCollection(data) {
    return this.http.delete(environment.apiBaseURI, data);
  }
}
