import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { RelationComponent } from '../relation/relation.component';
import { CountryService } from '../shared/country.service';


@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit {

  constructor(
    private countryService: CountryService,
    private relationComponent: RelationComponent) { }

  form = new FormGroup({
    relationId: new FormControl(''),
    name: new FormControl('', [Validators.required]),
    fullName: new FormControl('', [Validators.required]),
    telephoneNumber: new FormControl('', [Validators.required]),
    eMailAddress: new FormControl('', [Validators.required]),
    countryId: new FormControl('', [Validators.required]),
    city: new FormControl('', [Validators.required]),
    street: new FormControl('', [Validators.required]),
    postalCode: new FormControl('', [Validators.required]),
    number: new FormControl('', [Validators.required])
  });

  countries = [];

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(res => this.countries = res as []);
  }

  recordSubmit(form: FormGroup) {
    this.relationComponent.recordSubmit(form);
    
  }
}
