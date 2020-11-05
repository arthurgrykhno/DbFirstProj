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
    return this.http.put(environment.apiBaseURI + '/' + id, id);
  }

  deleteCollection(data) {
    return this.http.put(environment.apiBaseURI + '/deleteCollection', data);
  }

  getRelationsWithSorting(category, type) {
    return this.http.get(environment.apiBaseURI + '/relations/' + category + '/' + type);
  }

  getRelationsWithFilter(filterId) {
    return this.http.get(environment.apiBaseURI + '/relations/' + filterId);
  }
}
