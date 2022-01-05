import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AngularFireModule } from '@angular/fire/compat';
import { AngularFirestoreModule } from '@angular/fire/compat/firestore';
import { AngularFirestore } from '@angular/fire/compat/firestore';
import { AngularFireAuth } from '@angular/fire/compat/auth';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { environment } from 'src/environments/environment';
import { FeedComponent } from './task/feed.component';

@NgModule({
  declarations: [
    AppComponent,
    FeedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    AngularFireModule.initializeApp(environment.firebaseConfig),
    AngularFirestoreModule
  ],
  providers: [
    AngularFirestore,
    AngularFireAuth,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
