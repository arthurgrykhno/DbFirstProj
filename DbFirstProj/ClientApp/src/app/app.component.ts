import { Component, OnInit } from '@angular/core';
import { DataService } from './data/data.service';
import { Relation } from './data/data.relation';
import { MatDialogModule } from '@angular/material/dialog';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  providers: [DataService]
})
export class AppComponent implements OnInit {

  relation: Relation = new Relation();
  relations: Relation[];
  tablemode: boolean = true;

  getRel: Relation;

  constructor(private dataService: DataService) { }

  getAll() {
    this.dataService.getRelations().subscribe((data: Relation[]) => this.relations = data);
    console.log(this.relations);
  }

  delete(r: Relation) {
    this.dataService.deleteRelation(r.id).subscribe(data => this.getAll());
  }

  edit(r: Relation) {
    this.relation = r;
  }

  ngOnInit() {
    this.getAll();
  }
}
