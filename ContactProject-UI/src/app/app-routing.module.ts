import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';
import { ViewContactComponent } from './view-contact/view-contact.component';
import { AppComponent } from './app.component';


const routes: Routes = [
  { path:'',
  component:AppComponent
  },
  {
  path:'contact',
  component:ContactsComponent
  },
  {
    path:'contact/:id',
    component:ViewContactComponent
    },
    {
      path:'contact/add',
      component:ViewContactComponent
      }

  ]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
