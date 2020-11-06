import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CategoryService } from '../shared/category.service';
import { CountryService } from '../shared/country.service';
import { RelationService } from '../shared/relation.service';
import { MatDialog } from '@angular/material/dialog';
import { PopupComponent } from '../popup/popup.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-relation',
  templateUrl: './relation.component.html',
  styleUrls: ['./relation.component.css']
})
export class RelationComponent implements OnInit {

  relationForms: FormArray = this.fb.array([]);
  countries = [];
  notification = null;
  bin = [];
  type = false;
  categories = [];

  constructor(private fb: FormBuilder,
    private countryService: CountryService,
    private relationService: RelationService,
    private categoryService: CategoryService,
    public dialog: MatDialog,
    private toastr: ToastrService) { }

  openDialog() {
    const dialogRef = this.dialog.open(PopupComponent);

    dialogRef.afterClosed().subscribe(res => {
      console.log('dialog result: ${res}');
    });
  }

  showSuccess() {
    this.toastr.success('Successfully!');
  }

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(res => this.countries = res as []);

    this.categoryService.getCategories().subscribe(res => this.categories = res as []);

    this.relationService.getRelations().subscribe(
      res => {
        if (res == []) {
          this.addRelationForm();
        }
        else {
          (res as []).forEach((relation: any) => {
            this.relationForms.push(this.fb.group({
              relationId: [relation.relationId],
              relationAddressId: [relation.relationAddressId],
              countryId: [relation.countryId],
              isDisabled: [false],
              categoryId: [],

              name: [relation.name, Validators.required],
              fullName: [relation.fullName, Validators.required],
              telephoneNumber: [relation.telephoneNumber, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
              eMailAddress: [relation.eMailAddress, Validators.email],
              countryName: [relation.countryName],
              city: [relation.city, Validators.required],
              street: [relation.street, Validators.required],
              postalCode: [relation.postalCode, Validators.required],
              number: [relation.number, Validators.required]
            }));
          });
        }
      });
  }

  addRelationForm() {
    this.relationForms.push(this.fb.group({
      relationId: [''],
      relationAddressId: [''],
      countryId: [''],
      isDisabled: [false],

      name: ['', Validators.required],
      fullName: ['', Validators.required],
      telephoneNumber: ['', Validators.required],
      eMailAddress: ['', Validators.email],
      countryName: [''],
      city: ['', Validators.required],
      street: ['', Validators.required],
      postalCode: ['', Validators.required],
      number: [, Validators.required]
    }));
  }

  recordSubmit(fg: FormGroup) {
    if (fg.value.relationId == '') {
      this.relationService.postRelation(fg.value).subscribe(
        (res: any) => {
          fg.patchValue({ relationId: res.relationId });
          this.dialog.closeAll();
          this.showSuccess();
        });
      this.ngOnInit();
    }
    else {
      this.relationService.putRelation(fg.value).subscribe(
        (res: any) => {
          this.showSuccess();
        });
    }
  }

  onDelete(relationId, i) {
    if (relationId == '') {
      this.relationForms.removeAt(i);
    }
    else if (confirm('Are you sure?')) {
      this.relationService.deleteRelation(relationId).subscribe(
        res => {
          this.relationForms.removeAt(i);
        });
    }
  }

  onDeleteFromBin() {
    if (this.bin != null) {
      let ids = [];
      let indexes = [];
      this.bin.forEach(item => {
        ids.push(item.relationId);
        indexes.push(item.i);
      });

      console.log(indexes);
      this.relationService.deleteCollection(ids).subscribe(
        res => {
          for (let item of ids) {
            this.relationForms.removeAt(this.relationForms.value.findIndex(f => f.relationId == item));
          }
        });
    }
    this.bin = [];
  }

  addToBin(event, relationId, i) {
    if (event.target.checked) {
      this.bin.push({ relationId, i });
    }
    else {
      let removeIndex = this.bin.findIndex(item => item.i === i);
      if (removeIndex !== -1) {
        this.bin.splice(removeIndex, 1);
      }
    }
    console.log(this.bin);
  }

  sortBy(category) {
    this.type = !this.type;
    this.relationService.getRelationsWithSorting(category, this.type).subscribe(
      res => {
        while (this.relationForms.length !== 0) {
          this.relationForms.removeAt(0);
        }
        (res as []).forEach((relation: any) => {
          this.relationForms.push(this.fb.group({
            relationId: [relation.relationId],
            relationAddressId: [relation.relationAddressId],
            countryId: [relation.countryId],
            isDisabled: [false],

            name: [relation.name, Validators.required],
            fullName: [relation.fullName, Validators.required],
            telephoneNumber: [relation.telephoneNumber, Validators.required],
            eMailAddress: [relation.eMailAddress, Validators.required],
            countryName: [relation.countryName],
            city: [relation.city, Validators.required],
            street: [relation.street, Validators.required],
            postalCode: [relation.postalCode, Validators.required],
            number: [relation.number, Validators.required]
          }));
        });
      }
    )
  }

  onFilter(id) {
    this.relationService.getRelationsWithFilter(id).subscribe(
      res => {
        while (this.relationForms.length !== 0) {
          this.relationForms.removeAt(0);
        }
        (res as []).forEach((relation: any) => {
          this.relationForms.push(this.fb.group({
            relationId: [relation.relationId],
            relationAddressId: [relation.relationAddressId],
            countryId: [relation.countryId],
            isDisabled: [false],

            name: [relation.name, Validators.required],
            fullName: [relation.fullName, Validators.required],
            telephoneNumber: [relation.telephoneNumber, Validators.required],
            eMailAddress: [relation.eMailAddress, Validators.required],
            countryName: [relation.countryName],
            city: [relation.city, Validators.required],
            street: [relation.street, Validators.required],
            postalCode: [relation.postalCode, Validators.required],
            number: [relation.number, Validators.required]
          }));
        });
      }
    )
  }
}
