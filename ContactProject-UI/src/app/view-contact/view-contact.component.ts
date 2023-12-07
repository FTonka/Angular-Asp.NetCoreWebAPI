import { Component, OnInit } from '@angular/core';
import { ContactsService } from '../contacts/contacts.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { Contacts } from '../ui-model/Contacts.model';
import { MatSnackBar } from '@angular/material/snack-bar';




@Component({
  selector: 'app-view-contact',
  templateUrl: './view-contact.component.html',
  styleUrls: ['./view-contact.component.css'],

})
export class ViewContactComponent implements OnInit{

  contactid: number |null|undefined ;
  contact :Contacts={
    contactID:0,
    contactName:'',
    contactPhone:'',
    contactJob:'',
    contactEmail:'',
    contactAddress:'',
    contactWebPage:'',
    contactImage:''
  }
  isNewContact=false;
  header='';

  constructor(private readonly constactService:ContactsService , private readonly activatedRoute:ActivatedRoute
    ,private _snackBar: MatSnackBar,private router:Router){}
  ngOnInit(): void {

      this.activatedRoute.paramMap.subscribe(
        (params)=>{
          this.contactid=Number(params.get('id')) ;

        if(this.contactid){
          this.constactService.getContact(this.contactid).subscribe(
            (success)=>{
              this.contact=success;
            }
          );
        }}
      )
  }
  OnUpdate(){
    this.constactService.updateContact(this.contact.contactID,this.contact).subscribe(
      ()=>{
        this._snackBar.open("Kişi Bilgileri Güncellendi ",undefined,{duration:1500});
        setTimeout(()=>{
          this.router.navigateByUrl('/contact')
         },1500)


      },(errorResponse)=>{
        console.log(errorResponse);
      }
    )
  }
  OnDelete(){
    if(confirm("Silmek istediğinize emin misiniz?")){
    this.constactService.deleteContact(this.contact.contactID).subscribe(
      ()=>{
         this._snackBar.open("Kişi Rehberinizden Silindi",undefined,{duration:1500});
         setTimeout(()=>{
          this.router.navigateByUrl('/contact')
         },1500)
      },
      (errorResponse)=>{
        console.log(errorResponse)
      }
    )
  }


}
  OnSave():void{
    this.constactService.addContact(this.contact).subscribe(
      ()=>{
        this._snackBar.open("Kişi Rehberinize Eklendi",undefined,{duration:1500});
        setTimeout(()=>{
         this.router.navigateByUrl('/contact')
        },1500)
      },(errorResponse)=>{
        console.log(errorResponse);
      }
    )
  }



}
