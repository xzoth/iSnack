/// <reference path="../resources/script/sencha-touch-all.js" />
//<debug>
Ext.Loader.setPath({
    'Ext': 'sdk/src'
});
//</debug>

Ext.application({
    name: 'iSnackApp',
    viewport: { autoMaximize: true },
    apiUri: 'http://localhost:2030/api/',
    phoneStartupScreen: '',
    tableStartupScreen: '',
    icon: '',

    //应用程序启动函数
    launch: function () {
        Ext.Viewport.setMasked({ xtype: 'loadmask', message: '应用程序正在启动......', indicator: false });

        var welcomeView = Ext.create('Ext.carousel.Carousel',
        {
            title: '欢迎',
            xtype: 'carousel',
            iconCls: 'home',
            cls: 'home',
            defaults: { styleHtmlContent: true },
            items: [
                {
                    html: 'Senche Touch是一款强大的移动Web开发框架'
                },
                {
                    html: 'iSnake.Mobi DEMO通过演示来证明这一点',
                    style: 'background-color: #759E60'
                },
                {
                    html: '当然不仅于此...',
                    style: 'background-color: #5E99CC'
                }
            ]
        });

        var listView = Ext.create('Ext.Panel', {
            title: '产品列表',
            badgeText: '新',
            iconCls: 'star',
            id: 'listView',
            layout: { type: 'card', animation: { type: 'slide', easing: 'ease-in-out', direction: 'left'} },
            items:
                [{
                    xtype: 'list',
                    id: 'list',
                    ui: 'round',
                    emptyText: '没有数据',
                    grouped: true,
                    indexBar: false,
                    pinHeaders: false,
                    itemTpl: [
                                '<div style="width:195px;padding-top:0;font-size:16px;font-weight:bold">{Name}</div>',
                                '<div style="display:block;font-size:14px;font-weight:normal;color:#666">$ {Price}</div>'
                            ].join(''),
                    store:
                    {
                        fields: ['ID', 'Name', 'Category', 'Price', 'Remark'],
                        sorters: 'Price',
                        groupField: 'Category',
                        proxy: {
                            type: 'ajax',
                            url: iSnackApp.app.apiUri + 'Product',
                            useDefaultXhrHeader: false,
                            reader: { type: 'json', idProperty: 'ID' }
                        },
                        autoLoad: true
                    },
                    items: [
                                {
                                    xtype: 'toolbar',
                                    ui: 'neutral',
                                    items: [
                                        {
                                            xtype: 'searchfield',
                                            placeHolder: '搜索...',
                                            width: 180
                                        },
                                        { xtype: 'spacer' },
                                        {
                                            text: '添加',
                                            ui: 'confirm',
                                            iconMask: true,
                                            //iconCls: 'add',
                                            //width: 80,
                                            handler: function () {
                                                var listView = Ext.getCmp('listView');
                                                listView.getLayout().getAnimation().setDirection('left');
                                                listView.setActiveItem(1);

                                                var addForm = Ext.getCmp('addForm');
                                                addForm.reset();
                                            }
                                        }
                                    ]
                                }
                            ],
                    listeners: {
                        select: function (view, record) {
                            Ext.Msg.alert('你选择了', record.get('ID'));
                        }
                    },
                    onItemDisclosure: function (record, item, index, e) {
                        e.stopEvent();
                        //Ext.Msg.alert('api', iSnackApp.app.apiUri);
                    }
                },
                {
                    xtype: 'formpanel',
                    id: 'addForm',
                    scrollable: true,
                    padding: 10,
                    items:
                    [
                        {
                            xtype: 'titlebar',
                            title: '添加新产品',
                            docked: 'top',
                            items: [
                                {
                                    xtype: 'button',
                                    text: '取消',
                                    ui: 'back',
                                    align: 'left',
                                    handler: function () {
                                        var listView = Ext.getCmp('listView');
                                        listView.getLayout().getAnimation().setDirection('right');
                                        listView.setActiveItem(0);
                                    }
                                },
                                {
                                    xtype: 'button',
                                    text: '保存',
                                    ui: 'confirm',
                                    align: 'right',
                                    handler: function () {
                                        //                                        Ext.Ajax.request({
                                        //                                            url: iSnackApp.app.apiUri + 'Product',
                                        //                                            method: 'POST',
                                        //                                            params: Ext.getCmp('addForm').getValues(false),
                                        //                                            success: function (response, opts) {
                                        //                                                Ext.Msg.alert('成功', '保存成功');

                                        //                                                //切换至列表
                                        //                                                var listView = Ext.getCmp('listView');
                                        //                                                listView.getLayout().getAnimation().setDirection('right');
                                        //                                                listView.setActiveItem(0);

                                        //                                                //刷新列表
                                        //                                                var list = Ext.getCmp('list');
                                        //                                                list.getStore().reload();
                                        //                                            },
                                        //                                            failure: function (response, opts) {
                                        //                                                var text = response.responseText;
                                        //                                                if (response.timedout) {
                                        //                                                    Ext.Msg.alert('错误', '请求超时');
                                        //                                                }
                                        //                                                else if (response.aborted) {
                                        //                                                    Ext.Msg.alert('提示', '请求已取消');
                                        //                                                }
                                        //                                                else {
                                        //                                                    Ext.Msg.alert('失败', text);
                                        //                                                }
                                        //                                            },
                                        //                                            callback: function (opts, isSucc, response) {
                                        //                                                //todo callback
                                        //                                            }
                                        //                                        }
                                        //                                        );

                                        Ext.Viewport.setMasked({ xtype: 'loadmask', message: '正在保存', indicator: true });

                                        var addForm = Ext.getCmp('addForm');
                                        addForm.submit({
                                            url: iSnackApp.app.apiUri + 'Product',
                                            method: 'POST',
                                            success: function (form, result) {
                                                Ext.Viewport.setMasked(false);

                                                Ext.Msg.alert('成功', '保存成功');

                                                //切换至列表
                                                var listView = Ext.getCmp('listView');
                                                listView.getLayout().getAnimation().setDirection('right');
                                                listView.setActiveItem(0);

                                                //刷新列表
                                                var list = Ext.getCmp('list');
                                                list.getStore().load();
                                            },
                                            failure: function (form, result) {
                                                Ext.Viewport.setMasked(false);

                                                Ext.Msg.alert('失败', result.responseText);
                                            }
                                        });
                                    }
                                }
                            ]
                        },
                        {
                            xtype: 'fieldset',
                            title: '基本信息',
                            instructions: '必填项不能为空',
                            items: [
                                {
                                    xtype: 'textfield',
                                    name: 'ID',
                                    label: 'ID',
                                    disabled: true,
                                    placeHolder: '自动生成'
                                },
                                {
                                    xtype: 'textfield',
                                    name: 'Name',
                                    label: '产品名称',
                                    required: true,
                                    placeHolder: '必填'
                                }
                            ]
                        },
                        {
                            xtype: 'radiofield',
                            name: 'Category',
                            value: '电脑配件',
                            label: '电脑配件',
                            checked: true
                        },
                        {
                            xtype: 'radiofield',
                            name: 'Category',
                            value: '游戏机',
                            label: '游戏机'
                        },
                        {
                            xtype: 'fieldset',
                            title: '售价信息',
                            items: [
                                {
                                    xtype: 'numberfield',
                                    label: '价格',
                                    name: 'Price',
                                    required: true
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        var aboutView = Ext.create('Ext.Panel', {
            title: '关于',
            id: 'about',
            iconCls: 'more',
            layout: { type: 'card', animation: { type: 'slide', duration: 250, easing: 'ease-in-out', direction: 'left'} },
            scrollable: true,
            items: [
                {
                    xtype: 'panel',
                    layout: { type: 'vbox', pack: 'top', align: 'stretch' },
                    defaults: { margin: '10' },
                    items:
                    [
                        {
                            text: '提示框',
                            xtype: 'button',
                            ui: 'round',
                            handler: function () { Ext.Msg.alert('Hey', '提示框'); }
                        },
                        {
                            text: '输入框',
                            xtype: 'button',
                            ui: 'confirm-round',
                            handler: function () {
                                Ext.Msg.prompt('Hey', "请输入名称",
                                                    function (btn, text) {
                                                        if (btn == 'ok') {
                                                            Ext.Msg.alert('Hey', text);
                                                        }
                                                    }
                                                );
                            }
                        },
                        {
                            text: '确认框',
                            xtype: 'button',
                            ui: 'decline',
                            handler: function () {
                                Ext.Msg.confirm('Hey', '确定要**吗？',
                                    function (btn) {
                                        Ext.Msg.alert('Hey', '你点击了' + btn);
                                        if (btn == 'yes') {
                                        }
                                    }
                                )
                            }
                        },
                        {
                            text: '浮动提示',
                            xtype: 'button',
                            ui: 'plain',
                            iconMask: true,
                            iconCls: 'star',
                            handler: function (btn, e, opts) {
                                Ext.create('Ext.Panel', {
                                    html: '你好哇',
                                    title: 'Hey',
                                    padding: 10,
                                    modal: true,
                                    hideOnMaskTap: true
                                }).showBy(btn);
                            }
                        },
                        {
                            text: '新层',
                            xtype: 'button',
                            ui: 'action',
                            handler: function () {
                                var about = Ext.getCmp('about');
                                about.getLayout().getAnimation().setDirection('left');
                                about.setActiveItem(1);
                            }
                        },
                        {
                            text: '按钮',
                            xtype: 'button',
                            ui: 'dark'
                        },
                        {
                            text: '按钮',
                            xtype: 'button',
                            ui: 'neutral'
                        }
                    ]
                },
                {
                    xtype: 'panel',
                    html: '新的层',
                    padding: 10,
                    items: [
                        {
                            xtype: 'titlebar',
                            docked: 'top',
                            title: '新层',
                            items: [
                                {
                                    xtype: 'button',
                                    ui: 'back',
                                    text: '返回',
                                    handler: function () {
                                        var about = Ext.getCmp('about');
                                        about.getLayout().getAnimation().setDirection('right');
                                        about.setActiveItem(0);
                                    }
                                }
                            ]
                        }
                    ]
                }
            ]
        });

        Ext.Viewport.add({
            xtype: 'tabpanel',
            fullscreen: true,
            tabBarPosition: 'bottom',
            items:
                [
                    welcomeView,
                    listView,
                    aboutView
                ]
        });


        Ext.Viewport.setMasked(false);
    },

    onUpdated: function () {
        window.location.reload();
    }
});