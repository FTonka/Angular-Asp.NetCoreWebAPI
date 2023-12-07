import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import{Observable} from 'rxjs'
import { Contacts } from '../ui-model/Contacts.model';
import { UpdateContact } from '../api-models/update-contact.model';
import { AddContact } from '../api-models/add-contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  private APIURL="https://localhost:44393/Contact";
  constructor(private httpClient:HttpClient) { }

  getContacts():Observable<Contacts[]>{
    return this.httpClient.get<Contacts[]>(this.APIURL+"/GetAllContacts")
  }
  getContact(contactId:number):Observable<Contacts>{
    return this.httpClient.get<Contacts>(`${this.APIURL}/GetContact/${contactId}`)
  }
  updateContact(contactId :number, contactResponse:Contacts):Observable<Contacts>{
    const updateContact:UpdateContact={
      contactName:contactResponse.contactName,
      contactAddress:contactResponse.contactAddress,
      contactEmail:contactResponse.contactEmail,
      contactJob:contactResponse.contactJob,
      contactWebPage:contactResponse.contactWebPage,
      contactPhone:contactResponse.contactPhone,
      contactImage:contactResponse.contactImage

    }
    return this.httpClient.put<Contacts>(this.APIURL+"/UpdateContactAsync/"+contactId,updateContact)
  }
  deleteContact(contactId:number):Observable<Contacts>{
    return this.httpClient.delete<Contacts>(`${this.APIURL}/DeleteContactAsync/${contactId}`)
  }
  addContact(contactRequest:Contacts):Observable<Contacts>{
    const addContactRequest:AddContact={
      contactName:contactRequest.contactName,
      contactAddress:contactRequest.contactAddress,
      contactEmail:contactRequest.contactEmail,
      contactImage:contactRequest.contactImage,
      contactJob:contactRequest.contactJob,
      contactPhone:contactRequest.contactPhone,
      contactWebPage:contactRequest.contactWebPage
    }
    return this.httpClient.post<Contacts>(this.APIURL+'/AddContactAsync/',addContactRequest);
  }

}
