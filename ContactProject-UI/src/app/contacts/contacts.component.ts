import { Component, OnInit } from '@angular/core';
import { ContactsService } from './contacts.service';
import { Contacts } from '../ui-model/Contacts.model';


@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {
  contacts:Contacts[]=[];

  constructor(private contactsService:ContactsService){}

    ngOnInit():void{
      this.contactsService.getContacts()
      .subscribe({
        next: (contacts) => {
           this.contacts=contacts;
        },
        error: (response) =>  {
           console.log(response);
        }
        });
  }
}
