
import { NgModule } from '@angular/core'
import { RouterModule } from '@angular/router'
import { InventorItemsComponent } from './InventoryItems/inventory-items.component';
@NgModule({
    imports: [
        RouterModule.forRoot([
            { path: '', component: InventorItemsComponent },
            { path: 'InventoryItems', component: InventorItemsComponent },
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {

}