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
    telephoneNumber: new FormControl('', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("[0-9]{10}")]),
    eMailAddress: new FormControl('', [Validators.email]),
    countryId: new FormControl('', [Validators.required]),
    city: new FormControl('', [Validators.required]),
    street: new FormControl('', [Validators.required]),
    postalCode: new FormControl('', [Validators.required]),
    number: new FormControl('', [Validators.minLength(1), Validators.maxLength(7)])
  });

  numberValidation(input) {
    console.log((/[a-z]/.test(input.value.toLowerCase())))
  }

  countries = [];

  ngOnInit(): void {
    this.countryService.getCountries().subscribe(res => this.countries = res as []);
  }

  recordSubmit(form: FormGroup) {
    this.relationComponent.recordSubmit(form);

  }
}
