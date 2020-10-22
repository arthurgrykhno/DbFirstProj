import { Component, OnInit, Inject } from '@angular/core';
import { Relation } from '../data/data.relation';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { DataService } from '../data/data.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit {

  relation: Relation;

  constructor(@Inject(MAT_DIALOG_DATA) public data: Relation,
    public dataService: DataService,
    public dialog: MatDialog) { }


  ngOnInit(): void {
    this.relation = this.data;
  }

  edit(r: Relation) {
    this.dataService.editRelation(r).subscribe(this.dataService.getRelations);
    this.dialog.closeAll();
  }

}
