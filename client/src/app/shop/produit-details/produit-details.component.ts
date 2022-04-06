import { IProduct } from 'src/app/shared/models/product';
import { Component, OnInit } from '@angular/core';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-produit-details',
  templateUrl: './produit-details.component.html',
  styleUrls: ['./produit-details.component.scss']
})
export class ProduitDetailsComponent implements OnInit {
product : IProduct; 
  constructor(private shopService : ShopService, private activatedRoute :ActivatedRoute ) {  }

  ngOnInit(): void {
    this.loadProduct()
  }

  loadProduct(){
    let id : any 
    id = this.activatedRoute.snapshot.paramMap.get('id')
    this.shopService.getProduct(+id).subscribe(product => {
      this.product = product 
    }, error => {
      console.log(error)
    })
  }

}
