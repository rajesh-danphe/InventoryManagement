import { Component, OnInit } from '@angular/core'
import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { InventoryItemsModel } from './inventory-items.model';
import { HttpClient } from '@angular/common/http';

@Component({
    templateUrl: './inventory-items.component.html',
    animations: [
        trigger('fade', [
            state('void', style({ opacity: 0 })),
            transition(':enter,:leave', [
                animate(250)
            ])
        ])
    ]
})
export class InventorItemsComponent implements OnInit {

    public InventoryItemsValidate: FormGroup = null;
    public InventoryItemsList: Array<InventoryItemsModel> = new Array<InventoryItemsModel>();
    public InventoryItemsModel: InventoryItemsModel = new InventoryItemsModel();
    public showChild: boolean = false;
    public isEdit: boolean = false;
    public editRowId: number;
    constructor(public formBuilder: FormBuilder,
        public http: HttpClient) {
        this.GetAllItemsList();
    }

    ngOnInit() {
        this.InventoryItemsValidate = this.formBuilder.group({
            ItemName: ['', Validators.required],
            ItemDescription: ['', Validators.required],
            ItemPrice: ['', Validators.required],
            ItemIMG: ['']

        })

    }

    selectImage(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = (e: any) => {
                this.InventoryItemsValidate.controls['ItemIMG'].setValue(reader.result)
            }
            reader.readAsDataURL(input.files[0]);
        }
    }

    expandChild() {
        if (this.showChild) {
            this.showChild = false;
            this.Reset();
        } else {
            this.isEdit = false;
            this.showChild = true;
            this.Reset();
        }
    }
    GetAllItemsList() {
        this.http.get<any>("api/Inventory")
            .subscribe(res => {
                this.InventoryItemsList = res;
            }, err => {
                alert(err.error);
            })
    }
    Submit() {
        let CheckIsValid = true;
        if (!this.InventoryItemsValidate.valid) {
            for (var b in this.InventoryItemsValidate.controls) {
                this.InventoryItemsValidate.controls[b].markAsDirty();
                this.InventoryItemsValidate.controls[b].updateValueAndValidity();
                CheckIsValid = false;
            }
        }
        if (CheckIsValid) {
            this.InventoryItemsModel = this.InventoryItemsValidate.value;
            this.http.post("api/Inventory", this.InventoryItemsModel)
                .subscribe(res => {
                    this.GetAllItemsList();
                    this.showChild = false;
                    this.Reset();
                    alert("Successfully Inserted");

                }, err => {
                    alert(err.error);
                })

        } else {
            alert("Please fill mandatory fields.")
        }
    }
    Reset() {
        this.InventoryItemsValidate.reset();
    }
    Edit(row) {
        this.showChild = true;
        this.isEdit = true;
        this.InventoryItemsModel = row;
        this.InventoryItemsValidate.patchValue(row);
    }
    Update() {
        this.InventoryItemsModel.ItemDescription = this.InventoryItemsValidate.value.ItemDescription;
        this.InventoryItemsModel.ItemName = this.InventoryItemsValidate.value.ItemName;
        this.InventoryItemsModel.ItemPrice = this.InventoryItemsValidate.value.ItemPrice;
        this.InventoryItemsModel.ItemIMG = this.InventoryItemsValidate.value.ItemIMG;
        this.http.put("api/Inventory", this.InventoryItemsModel)
            .subscribe(res => {
                this.GetAllItemsList();
                this.showChild = false;
                this.Reset();
                alert("Successfully Updated");

            }, err => {
                alert(err.error);
            })

    }
    Delete(row) {
        this.http.delete("api/Inventory/" + row.ItemId)
            .subscribe(res => {
                this.GetAllItemsList();
                this.showChild = false;
                this.Reset();
                alert("Successfully Delete");

            }, err => {
                alert(err.error);
            })
    }
}
