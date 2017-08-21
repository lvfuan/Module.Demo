jQuery(function () {
    Demo1Init();
});
function Demo1Init() {
    jQuery("#demo1").jqGrid({
        url: 'JqGrid/GetDemoDB',        //请求路径
        datatype: 'json',    //返回数据类型
        colNames: ['KID', '商品SKU', '名称', '商品条码', '状态'],//列头
        colModel: [  //设置列绑定值(常用到的属性：name 列显示的名称；index 传到服务器端用来排序用的列名称；width 列宽度；align 对齐方式；sortable 是否可以排序)
            { name: 'KID', index: 'KID', width: 200, align: 'center' },
            { name: 'SkuNo', index: 'SkuNo', width: 200, align: 'center' },
            { name: 'ProductSkuName', index: 'ProductSkuName', width: 200, align: 'center' },
            { name: 'SkuBarCode', index: 'SkuBarCode', width: 200, align: 'center' },
            { name: 'State', index: 'State', width: 55, align: 'center' }
        ],
        rowNum: 10,                //页大小
        rowList: [10, 20, 30],     //可选择地页大小
        page: '#page1',            //分页id
        sortname: 'AutogRowID',    //默认排序字段
        mtype: 'post',             //提交方式
        viewrecords: true,         //是否显示总记录
        sortorder: 'desc',         //排序类型
        caption: 'JqGrid Demo1'    //表格名称
    });
    jQuery("#demo1").jqGrid('navGrid', '#page1', { edit: false, add: false, del: false });
};
 