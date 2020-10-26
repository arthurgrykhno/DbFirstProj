import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryService } from '../shared/country.service';
import { RelationService } from '../shared/relation.service';

@Component({
  selector: 'app-relation',
  templateUrl: './relation.component.html',
  styleUrls: ['./relation.component.css']
})
export class RelationComponent implements OnInit {

  relationForms: FormArray = this.fb.array([]);
  countries = [];

  constructor(private fb: FormBuilder,
    private countryService: CountryService,
    private relationService: RelationService) { }

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(res => this.countries = res as []);

    this.relationService.getRelations().subscribe(
      res => {
        if (res == []) {
          this.addRelationForm();
        }
        else {
          (res as []).forEach((relation: any) => {
            this.relationForms.push(this.fb.group({
              relationId: [relation.relationId], //!!!!!
              relationAddressId: [relation.relationAddressId], //!!!!!!
              countryId: [relation.countryId], //!!!!!
              isDisabled: [false], //!!!!!!

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
      }
    )
  }

  addRelationForm() {
    this.relationForms.push(this.fb.group({
      relationId: [''], //!!!!!
      relationAddressId: [''], //!!!!!!
      countryId: [''], //!!!!!
      isDisabled: [false], //!!!!!!

      name: ['', Validators.required],
      fullName: ['', Validators.required],
      telephoneNumber: ['', Validators.required],
      eMailAddress: ['', Validators.required],
      countryName: [''],
      city: ['', Validators.required],
      street: ['', Validators.required],
      postalCode: ['', Validators.required],
      number: [, Validators.required]
    }));
  }

  recordSubmit(fg: FormGroup) {
    this.relationService.postRelation(fg.value).subscribe(
      (res: any) => {
        fg.patchValue({ relationId: res.relationId });
      }
    )
  }
}
