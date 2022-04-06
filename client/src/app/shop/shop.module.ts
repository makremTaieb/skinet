import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProduitDetailsComponent } from './produit-details/produit-details.component';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,
    ProduitDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule
  ], exports: [
    ShopComponent,
    
  ],
})
export class ShopModule { }
