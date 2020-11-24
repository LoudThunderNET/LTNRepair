import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Controls, NgxSubFormComponent, subformComponentProviders } from 'ngx-sub-form';
import { TreeNode } from 'primeng/api';
import { Dialog } from 'primeng/dialog';
import { Equipment } from 'src/app/domain/equipment';
import { EquipmentService } from 'src/app/services/EquipmentService/equipment.service';
import {tap} from 'rxjs/operators';

@Component({
  selector: 'app-equipment',
  templateUrl: './equipment.component.html',
  styleUrls: ['./equipment.component.scss'],
  providers: subformComponentProviders(EquipmentComponent)
})
export class EquipmentComponent extends NgxSubFormComponent<Equipment>{
  treeNodes:TreeNode[] = [];
  selectedNode:TreeNode = null;
  selectedEquipment:Equipment = null;
  equipments: Equipment[] = [];

  constructor(private equipmentService : EquipmentService){
    super();
  }

  showChooseEquipmentDlg:boolean = false;

  protected getFormControls(): Controls<Equipment> {
    return {
      id:new FormControl(),
      name:new FormControl(),
      availableComplectation: new FormControl(),
      isNode:new FormControl(),
      parentId:new FormControl()
    };
  }

  onClickChooseEquipmentDlgButton(event){
    this.showChooseEquipmentDlg = true;
  }

  onChooseEquipmentShowing(event, dialog: Dialog){
    dialog.maximize();
    const sub = this.equipmentService.getByFilter({ node:true })
    .pipe(
      tap(response =>{
          this.treeNodes = [{
            label:'Все',
            key: 'all',
            data: {id:null},
            expandedIcon: "pi pi-folder-open",
            collapsedIcon: "pi pi-folder",
            expanded:true,
            children:[]
          }];
          this.buildTree(this.treeNodes, this.treeNodes[0], response, null);
        })
      )
    .subscribe(()=>sub.unsubscribe());
  }

  onSaveButtonClick(event){
    this.formGroupControls.availableComplectation.setValue(this.selectedEquipment.availableComplectation);
    this.formGroupControls.id.setValue(this.selectedEquipment.id);
    this.formGroupControls.isNode.setValue(this.selectedEquipment.isNode);
    this.formGroupControls.name.setValue(this.selectedEquipment.name);
    this.formGroupControls.parentId.setValue(this.selectedEquipment.parentId);

    this.showChooseEquipmentDlg = false;
  }

  onChooseEquipmentHiding(event){
    this.hideDialog();
  }

  onCancelButtonClick(event){
    this.hideDialog();
  }
  
  loadGroupEquipments(event){
    const parentIds = this.getChildrenNodesIds([], this.selectedNode);
    this.equipmentService.getByFilter({ parentIds: parentIds, node:false}).subscribe(r=>{
      this.equipments = r;
      this.selectedEquipment = null;
    });
  }
  
  private hideDialog(){
    this.showChooseEquipmentDlg = false;
  }

  private buildTree(treeNodes:TreeNode[], parentNode:TreeNode, equipments: Equipment[], parentId:number){
    const children = equipments.filter((equipment, index, array)=>{
      return equipment.isNode && equipment.parentId === parentId;
    });

    for(var i = 0; i< children.length; i++){
      const child = children[i];
      const currentNode: TreeNode = {
        key: `${child.id}`,
        label: child.name,
        data: child,
        expandedIcon: "pi pi-folder-open",
        collapsedIcon: "pi pi-folder",
        children:[]
      };

      if(parentNode === null){
        treeNodes.push(currentNode);
      }
      else{
          parentNode.children.push(currentNode);
      }

      this.buildTree(treeNodes, currentNode, equipments, child.id);
    }
  }

  private getChildrenNodesIds(childrenNodeIds: number[], parent: TreeNode): number[]{
    childrenNodeIds.push(parent.data.id);
    const children = parent.children.filter((e,i,a)=>e.data.parentId == parent.data.id);
    for(var i = 0; i < children.length; i++){
      this.getChildrenNodesIds(childrenNodeIds, children[i])
    }

    return childrenNodeIds;
  }
}
