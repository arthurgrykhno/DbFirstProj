import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { PopupComponent } from './popup/popup.component';
import { DataService } from './data/data.service';


@NgModule({
  declarations: [
    AppComponent,
    PopupComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatDialogModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [DataService, AppComponent],
  bootstrap: [AppComponent],
  entryComponents: [PopupComponent]
})
export class AppModule { }
