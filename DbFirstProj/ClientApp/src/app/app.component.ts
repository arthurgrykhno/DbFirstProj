import { Component, OnInit } from '@angular/core';
import { DataService } from './data/data.service';
import { Relation } from './data/data.relation';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PopupComponent } from './popup/popup.component';


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

  constructor(private dataService: DataService, public dialog: MatDialog) { }

  getAll() {
    this.dataService.getRelations().subscribe((data: Relation[]) => this.relations = data);
    console.log(this.relations);
  }

  delete(r: Relation) {
    this.dataService.deleteRelation(r.relationId).subscribe(data => this.getAll());
  }

  onEdit(r: Relation) {
    this.relation = r;
    this.dialog.open(PopupComponent,{
      data: this.relation
    });
  }

  edit(r: Relation) {
    this.dataService.editRelation(r);
  }
  

  ngOnInit() {
    this.getAll();
  }
}
