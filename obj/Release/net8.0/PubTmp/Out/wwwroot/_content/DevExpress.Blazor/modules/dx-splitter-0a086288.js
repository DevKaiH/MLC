import{_ as e}from"./tslib.es6-d65164b3.js";import{S as t}from"./single-slot-element-base-6c879161.js";import{s as i}from"./enumConverter-6047c3ff.js";import{n as s}from"./property-4ec0b52d.js";import{e as r}from"./custom-element-267f9a21.js";import"./data-qa-utils-8be7c726.js";import"./const-90026e45.js";import"./dx-ui-element-38985cf5.js";import"./lit-element-base-be4d2d51.js";import"./dx-license-7b9121f4.js";import"./lit-element-462e7ad3.js";import"./logicaltreehelper-39bf56ef.js";import"./layouthelper-b10d5065.js";import"./point-e4ec110e.js";import"./constants-7c047c0d.js";var o,l;!function(e){e[e.Horizontal=0]="Horizontal",e[e.Vertical=1]="Vertical"}(o||(o={}));let a=l=class extends t{constructor(){super(...arguments),this._orientation=null}get isVertical(){return this._orientation===o.Vertical}};a.TagName="dxbl-splitter",e([s({type:o,converter:i(o),attribute:"orientation"})],a.prototype,"_orientation",void 0),a=l=e([r(l.TagName)],a);let n=class extends t{constructor(){super(...arguments),this.forceIsFlexible=!1,this._size=null,this.minSize=null,this.maxSize=null}get size(){return this.style.flexBasis}set size(e){this.style.flexBasis=e}updated(e){super.updated(e),e.has("forceIsFlexible")&&this.forceIsFlexible&&(this.size=""),e.has("_size")&&this.setInitialSize()}setInitialSize(){var e;this.size=null!==(e=this._size)&&void 0!==e?e:""}};e([s({type:Boolean,attribute:"force-flexible"})],n.prototype,"forceIsFlexible",void 0),e([s({type:String,attribute:"size"})],n.prototype,"_size",void 0),e([s({type:String,attribute:"min-size"})],n.prototype,"minSize",void 0),e([s({type:String,attribute:"max-size"})],n.prototype,"maxSize",void 0),n=e([r("dxbl-splitter-pane")],n);export{a as DxSplitter,n as DxSplitterPane};
