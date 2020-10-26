import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder } from '@angular/forms';
import { CountryService } from '../shared/country.service';

@Component({
  selector: 'app-relation',

  templateUrl: './relation.component.html',
  styleUrls: ['./relation.component.css']
})
export class RelationComponent implements OnInit {
  
  relationForms: FormArray = this.fb.array([]);
  countries = [];

  constructor(private fb: FormBuilder, private countryService: CountryService) { }

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(res => this.countries = res as []);
    this.addRelationForm();
  }

  addRelationForm(){
    this.relationForms.push(this.fb.group({
      relationId: [''],
      relationAddressId: [''],
      countryId: [''],
      isDisabled: [false],
      name: [''],
      fullName: [''],
      telephoneNumber: [''],
      eMailAddress: [''],
      countryName: [''],
      city: [''],
      street: [''],
      postalCode: [''],
      number: [0]
    }));
  }
}
