<%@ Page Language="VB" AutoEventWireup="true" Inherits="BIWeb.Defaultw" Debug="true" EnableSessionState ="True" EnableViewState ="true"  Codebehind="Defaultw.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat ="server"  id="Head1">
    <meta http-equiv="X-UA-Compatible" content="IE=9,10,11,Edge,chrome=1"/> 
    <meta name="title" content="<%=comptitle %>" />
    <meta name="description" content="<%=compdesc %>" />
    <link rel="image_src" href="<%=aspximage1.imageurl %>" />

    
	<title>Cockpit</title>
               
        <script type="text/javascript" src="js/jquery-1.11.3.js"></script>        
        <script type="text/javascript" src="js/js.cookie.js"></script>
        <script type="text/javascript" src="js/jquery-ui-1.10.3.custom.min.js"></script>
        <script type="text/javascript" src="js/jquery.contextmenu.js"></script>
        <script type="text/javascript" src="js/globalize.js"></script>
        <script type="text/javascript" src="js/cultures/globalize.cultures.js"></script>
        <link rel="stylesheet" type="text/css" href="js/jquery.contextMenu.css"/>
   	
		<script type="text/javascript" src="js/jquery-ui-1.11.3.js"></script>        
        <script type="text/javascript" src="js/jquery-ui-1.11.3.min.js"></script>        
                
        <script type="text/javascript" src="js/knockout-3.4.0.js"></script>
        
        <script type="text/javascript" src="js/jquery.ui.position.js"></script>
        <script type="text/javascript" src="js/jquery.ui.position.min.js"></script>		


     <style type="text/css">
        .inline-zone{
            float:left;
        }
        .fit-image{
            height:100%;
            width:100%;
            object-fit: contain;
        }
        .dock-panel{
            overflow:hidden !important; 
        }
    </style>

    <style type="text/css">
        body, html
        {
            padding: 0;
            margin: 0;
        }        
    </style>

    <style type ="text/css">
    .dx-list-item-content, .dx-list .dx-empty-message {font-size: 16px;}

    .dx-list-select-all-label {font-size: 16px;}
    </style>

    <style type="text/css" >
        .dx-dashboard-item-header {
            height:auto;
        }
    </style>

      <script type="text/javascript" >
          function DataLoadingError(s, e) {
              e.SetError(s.cp_Error);
          }
      </script>
             

     <script type="text/javascript">

         function OnInit(s, e) {
             AdjustSize();

             ASPxClientUtils.AttachEventToElement(window, "resize", function (evt) {
                 AdjustSize();
             });

             var loadingPanel = $('.dx-dashboard-loading');
             loadingPanel.css('margin-top', $(window).height() / 3 - loadingPanel.height());

         }

         function AdjustSize() {
             var height = (document.documentElement.clientHeight) ;
             // var height = viewport - document.getElementById('topMenu').offsetHeight;
             
             //var dhe = pc.GetMainElement().parentNode.offsetHeight;
             //if (dhe == 518) {
             var wid = document.getElementById('heightp').value;
             //alert ("wid= " + wid);
             if (wid != '' && wid != '0') {
                 pc.SetHeight(wid);
                 //dashboardViewer.SetHeight(height);
             } else {
                 //alert("height= " + height);
                 pc.SetHeight(height);
                 try {
                     dashboardViewer.SetHeight(height);
                 } catch (err) {                     
                 }                 
             }
         }

    </script>

        <script type="text/javascript">
            function copyTextToClipboard(text) {
                var textArea = document.createElement("textarea");

                // Place in top-left corner of screen regardless of scroll position.
                textArea.style.position = 'fixed';
                textArea.style.top = 0;
                textArea.style.left = 0;

                // Ensure it has a small width and height. Setting to 1px / 1em
                // doesn't work as this gives a negative w/h on some browsers.
                textArea.style.width = '2em';
                textArea.style.height = '2em';

                // We don't need padding, reducing the size if it does flash render.
                textArea.style.padding = 0;

                // Clean up any borders.
                textArea.style.border = 'none';
                textArea.style.outline = 'none';
                textArea.style.boxShadow = 'none';

                // Avoid flash of white box if rendered for any reason.
                textArea.style.background = 'transparent';


                textArea.value = text;

                document.body.appendChild(textArea);

                textArea.select();

                try {
                    var successful = document.execCommand('copy');
                    var msg = successful ? 'successful' : 'unsuccessful';
                    console.log('Copying text command was ' + msg);
                } catch (err) {
                    console.log('Oops, unable to copy');
                }

                document.body.removeChild(textArea);
            }
        </script>

        <script type="text/javascript">

            function compartilhar() {
                // alert('aqui..');
                    var mobileSO = getMobileOperatingSystem();

                    var linkc = document.getElementById('<%#linkc.ClientID %>');
                    if (!(typeof (linkc) != 'undefined' && linkc != null)) {
                        linkc = document.getElementById('linkc');
                    }
                    var linkc1 = document.getElementById('<%#linkc1.ClientID %>');
                    if (!(typeof (linkc1) != 'undefined' && linkc1 != null)) {
                        linkc1 = document.getElementById('linkc1');
                    }

                    var urlCompartilhar = linkc.value;

                    if (mobileSO == "Android") {
                        mybiandroid.compartilhar(urlCompartilhar);
                    } else if (mobileSO == "iOS") {
                        window.location = 'mybiios://?url=' + urlCompartilhar;
                    }

                    // alert(linkc1.value);
                    copyTextToClipboard(linkc1.value);
                    alert("Link copiado para área de transferência: " + linkc1.value);

                    return false;

            }


        function getMobileOperatingSystem() {
            var userAgent = navigator.userAgent || navigator.vendor || window.opera;

            // Windows Phone must come first because its UA also contains "Android"
            if (/windows phone/i.test(userAgent)) {
                return "Windows Phone";
            }

            if (/android/i.test(userAgent)) {
                return "Android";
            }

            // iOS detection from: http://stackoverflow.com/a/9039885/177710
            if (/iPad|iPhone|iPod/.test(userAgent) && !window.MSStream) {
                return "iOS";
            }

            return "unknown";
        }
    </script>

    <script type="text/javascript">
        var preventClose = true;

        function CloseGridLookup1a() {
            preventClose = false;
            gridLookup1a.ConfirmCurrentSelection();
            gridLookup1a.HideDropDown();
            gridLookup1a.Focus();
            preventClose = true;
        }

        function CloseGridLookup1b() {
            preventClose = false;
            gridLookup1b.ConfirmCurrentSelection();
            gridLookup1b.HideDropDown();
            gridLookup1b.Focus();
            preventClose = true;
        }

        function CloseGridLookup1c() {
            preventClose = false;
            gridLookup1c.ConfirmCurrentSelection();
            gridLookup1c.HideDropDown();
            gridLookup1c.Focus();
            preventClose = true;
        }

        function CloseGridLookup1d() {
            preventClose = false;
            gridLookup1d.ConfirmCurrentSelection();
            gridLookup1d.HideDropDown();
            gridLookup1d.Focus();
            preventClose = true;
        }

        function CloseGridLookup1e() {
            preventClose = false;
            gridLookup1e.ConfirmCurrentSelection();
            gridLookup1e.HideDropDown();
            gridLookup1e.Focus();
            preventClose = true;
        }

        function CloseGridLookup1es() {
            preventClose = false;
            gridLookup1es.ConfirmCurrentSelection();
            gridLookup1es.HideDropDown();
            gridLookup1es.Focus();
            preventClose = true;
        }

        function CloseGridLookup1es1() {
            preventClose = false;
            gridLookup1es1.ConfirmCurrentSelection();
            gridLookup1es1.HideDropDown();
            gridLookup1es1.Focus();
            preventClose = true;
        }

        function CloseGridLookup1f() {
            preventClose = false;
            gridLookup1f.ConfirmCurrentSelection();
            gridLookup1f.HideDropDown();
            gridLookup1f.Focus();
            preventClose = true;
        }

        function CloseGridLookup1() {
            preventClose = false;
            gridLookup1.ConfirmCurrentSelection();
            gridLookup1.HideDropDown();
            gridLookup1.Focus();
            preventClose = true;
        }
        

        function OnQueryCloseUp(s, e) {
            //e.cancel = preventClose;
        }

    </script>



        <script type="text/javascript">
            function GetDashboardItemData(viewer, itemName) {
                var itemData = viewer.GetItemData(itemName),
                    data = undefined,
                    axisNames = itemData.GetAxisNames();
                if (axisNames.length > 1) {
                    if (axisNames.indexOf('Row') >= 0 && axisNames.indexOf('Column') >= 0) {
                        data = GetTwoDimensionsData(itemData, 'Column', 'Row', true);
                    }
                    if (axisNames.indexOf('Argument') >= 0 && axisNames.indexOf('Series') >= 0) {
                        data = GetTwoDimensionsData(itemData, 'Series', 'Argument');
                    }
                    if (axisNames.indexOf('Sparkline') >= 0) {
                        var index = axisNames.indexOf('Sparkline');
                        axisNames.splice(index, 1);
                        data = GetOneDimensionData(itemData, axisNames[0]);
                    }
                }
                else {
                    data = GetOneDimensionData(itemData, axisNames[0]);
                }
                return JSON.stringify({ I: itemName, D: data });
            }

            function GetOneDimensionData(itemData, axisName) {
                var axis = itemData.GetAxis(axisName),
                    dimensions = axis.GetDimensions(),
                    measures = itemData.GetMeasures(),
                    rows = [],
                    headers = [];

                $.each(dimensions, function (_, dimension) {
                    headers.push(dimension.Name);
                });
                $.each(measures, function (_, measure) {
                    headers.push(measure.Name);
                });
                rows.push(headers);
                $.each(axis.GetPoints(), function (_, axisPoint) {
                    var row = [];
                    $.each(dimensions, function (_, dimension) {
                        var dimensionValue = axisPoint.GetDimensionValue(dimension.Id);
                        row.push(dimensionValue.GetDisplayText());
                    });
                    var dataSlice = itemData.GetSlice(axisPoint);
                    $.each(measures, function (_, measure) {
                        var measureValue = dataSlice.GetMeasureValue(measure.Id);
                        row.push(measureValue.GetValue());
                    });
                    rows.push(row);
                });
                return rows;
            }


            function GetAxisData(itemData, name, getTotals) {
                var axis = itemData.GetAxis(name),
                        rootPoint = axis.GetRootPoint(),
                        points = [],
                        maxLevel;

                if (getTotals) {
                    maxLevel = GetPointsRecursive(points, rootPoint, 0)
                    points.push(rootPoint);
                }
                else {
                    maxLevel = axis.GetDimensions().length;
                    if (maxLevel == 0) {
                        points.push(axis.GetRootPoint());
                    }
                    else {
                        points = axis.GetPoints();
                    }
                }
                return {
                    Axis: axis,
                    AxisPoints: points,
                    MaxLevel: maxLevel
                };
            }
            function GetPointsRecursive(points, point, parentLevel) {
                var currentLevel = parentLevel;
                $.each(point.GetChildren(), function (_, child) {
                    var childrenLevel = GetPointsRecursive(points, child, parentLevel + 1);
                    points.push(child);
                    if (childrenLevel > currentLevel)
                        currentLevel = childrenLevel;
                });
                return currentLevel;
            }
            function GetTwoDimensionsData(itemData, columnsAxisName, rowAxisName, getTotals) {
                var columnData = GetAxisData(itemData, columnsAxisName, getTotals),
                    rowData = GetAxisData(itemData, rowAxisName, getTotals),
                    rows = [],
                    columnDimensions = columnData.Axis.GetDimensions(),
                    measures = itemData.GetMeasures();
                for (var rowIndex = 0; rowIndex < columnData.MaxLevel; rowIndex++) {
                    var row = [];
                    row[rowData.MaxLevel - 1] = undefined;
                    $.each(columnData.AxisPoints, function (_, point) {
                        if (measures.length > 1) {
                            $.each(measures, function (_, measure) {
                                row.push(GetPointValue(point, rowIndex, columnDimensions));
                            });
                        }
                        else {
                            row.push(GetPointValue(point, rowIndex, columnDimensions));
                        }
                    });
                    rows.push(row);
                }
                if (measures.length > 1) {
                    var row = [];
                    row[rowData.MaxLevel - 1] = undefined;
                    $.each(columnData.AxisPoints, function (_, point) {
                        $.each(measures, function (_, measure) {
                            row.push(measure.Name);
                        });
                    });
                    rows.push(row);
                }

                $.each(rowData.AxisPoints, function (_, rowPoint) {
                    var row = [],
                        rowDimensions = rowData.Axis.GetDimensions();
                    for (var columnIndex = 0; columnIndex < rowData.MaxLevel; columnIndex++) {
                        row.push(GetPointValue(rowPoint, columnIndex, rowDimensions));
                    }
                    var rowSlice = itemData.GetSlice(rowPoint);
                    if (measures.length > 0) {
                        $.each(columnData.AxisPoints, function (_, columnPoint) {
                            var cellSlice = rowSlice.GetSlice(columnPoint);
                            $.each(measures, function (_, measure) {
                                var measureValue = cellSlice.GetMeasureValue(measure.Id);
                                row.push(measureValue.GetValue());
                            });
                        });
                    }
                    else {
                        $.each(columnData.AxisPoints, function (_, columnPoint) {
                            row.push();
                        });
                    }
                    rows.push(row);
                });
                return rows;
            }
            function GetPointValue(point, level, dimensions) {
                var dimensionsLength = point.GetDimensions().length;
                if ((dimensionsLength == 0 && level == 0) || dimensionsLength == level + 1) {
                    return point.GetDisplayText();
                }
                else {
                    if (dimensionsLength > level) {
                        return point.GetDimensionValue(dimensions[level].Id).GetDisplayText();
                    }
                    else {
                        return '';
                    }
                }
            }
        </script>

        <style type ="text/css">          
        td {
            border-radius: 5px;
        }​
        </style> 


        <script type="text/javascript">            
            function OnTimeCellDoubleClick(s, e) {
                ASPx.Evt.AttachEventToElement(clientScheduler.GetMainElement(), 'dblclick', function (evt) {
                    if (clientScheduler.activeFormType == ASPx.SchedulerFormType.None) {
                        evt = ASPx.Evt.GetEvent(evt);
                        var hitTestResult = clientScheduler.CalcHitTest(evt);
                        if (hitTestResult.cell != null && hitTestResult.cell.className == "dxscTimeCellBody")
                            if (!ASPx.IsExists(hitTestResult.appointmentDiv))
                                clientScheduler.RaiseCallback('MNUVIEW|NewAppointment');
                    }
                });
            }

            function OnAppointmentDoubleClick(s, e) {
                clientScheduler.RaiseCallback('MNUAPT|OpenAppointment');

            }
    </script>
        
    		<script type="text/javascript">    	

    	
    		    $(function () {
                function setGetParameter(url, paramName, paramValue) {
		            if (url.indexOf(paramName + "=") >= 0) {
		                var prefix = url.substring(0, url.indexOf(paramName));
		                var suffix = url.substring(url.indexOf(paramName)).substring(url.indexOf("=") + 1);
		                suffix = (suffix.indexOf("&") >= 0) ? suffix.substring(suffix.indexOf("&")) : "";
		                url = prefix + paramName + "=" + paramValue + suffix;
		            }
		            else {
		                if (url.indexOf("?") < 0)
		                    url += "?" + paramName + "=" + paramValue;
		                else
		                    url += "&" + paramName + "=" + paramValue;
		            }
		            return url;
		        }


		    });
		    
			 
    		    $(function () {
    		        function setGetParameter(url, paramName, paramValue) {
    		            if (url.indexOf(paramName + "=") >= 0) {
    		                var prefix = url.substring(0, url.indexOf(paramName));
    		                var suffix = url.substring(url.indexOf(paramName)).substring(url.indexOf("=") + 1);
    		                suffix = (suffix.indexOf("&") >= 0) ? suffix.substring(suffix.indexOf("&")) : "";
    		                url = prefix + paramName + "=" + paramValue + suffix;
    		            }
    		            else {
    		                if (url.indexOf("?") < 0)
    		                    url += "?" + paramName + "=" + paramValue;
    		                else
    		                    url += "&" + paramName + "=" + paramValue;
    		            }
    		            return url;
    		        }

    		    });
       
function roundNumber(num, dec) {
    var result = Math.round(Math.round(num * Math.pow(10, dec + 1)) / Math.pow(10, 1)) / Math.pow(10, dec);
    return result;
}


</script>
	        

   
   	
<script type ="text/javascript" >
var isClose = false;
//this code will handle the F5 or Ctrl+F5 key+
//need to handle more cases like ctrl+R whose codes are not listed here
document.onkeydown = checkKeycode
window.onbeforeunload = doUnload;
function checkKeycode(e)
{
    var keycode;
    if (window.event)
        keycode = window.event.keyCode;
    else if (e)
        keycode = e.which;
    if(keycode == 116)
    {
        isClose = true;
    }
    //isClose = true;
    //alert(isClose);
}

function somefunction()
{
    isClose = true;
}

function doUnload()
{
    //alert(isClose);
    if(!isClose)
    {
        if (window.ActiveXObject) { // code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            xmlhttp.open("GET", "modulos_sair.aspx", false);
            xmlhttp.send();
        }
        if (window.XMLHttpRequest) {
            // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", "modulos_sair.aspx", false);
            xmlhttp.send();
        }
    }
}
</script>

            <script type="text/javascript">

                function scanBarCode() {

                    var mobileSO = getMobileOperatingSystem();

                    if (mobileSO == "Android") {
                        mybiandroid.scanBarCode();
                    } else if (mobileSO == "iOS") {
                        window.location = 'mybiios://?barcode';
                    }
                    return false;
                }

                function setCodeResult(code) {

                    var inputName = "textbox1x";
                    $('input[name="' + inputName + '"]').val(code);
                }
        </script>


<style type="text/css" >#tabpage { min-height:100%; min-width:100%; } </style>      
<style type="text/css" >
        .dx-dashboard-item-header {
            height:auto;
        }
        .dx-dashboard-title {
            font-size: 42px;
            padding-top: 10px;
            padding-bottom: 10px;
        }
        .dx-icon-dashboard-export {
            width: 50px;
            height: 50px;
            background-size: cover;
        }
</style>

</head>

<body onmousedown="somefunction()">

    <script type="text/javascript">

        function onLoaded(s, e) {
            var headers = document.getElementsByClassName("dx-item-header")
            for (i = 0; i < headers.length; i++) {
                //if (headers[i].innerText.indexOf('Grid 1') != -1) {
                //    debugger;
                    headers[i].style.fontSize = "80px";
                //}
            }
            
            try {
            if (s.cp_CardColor != '') {
                var elements = document.querySelectorAll("div[data-layout-item-name='cardDashboardItem1'] .dx-flex-card-layout");
                //alert(elements.length);
                for (i = 0; i < elements.length; ++i) {
                    elements[i].style.backgroundColor = s.cp_CardColor;
                }
            }
            if (s.cp_CardColor1 != '') {
                var elements = document.querySelectorAll("div[data-layout-item-name='cardDashboardItem2'] .dx-flex-card-layout");
                for (i = 0; i < elements.length; ++i) {
                    elements[i].style.backgroundColor = s.cp_CardColor1;
                }
            }
            if (s.cp_CardColor2 != '') {
                var elements = document.querySelectorAll("div[data-layout-item-name='cardDashboardItem3'] .dx-flex-card-layout");
                for (i = 0; i < elements.length; ++i) {
                    elements[i].style.backgroundColor = s.cp_CardColor2;
                }
            }
            if (s.cp_CardColor3 != '') {
                var elements = document.querySelectorAll("div[data-layout-item-name='cardDashboardItem4'] .dx-flex-card-layout");
                for (i = 0; i < elements.length; ++i) {
                    elements[i].style.backgroundColor = s.cp_CardColor3;
                }
            }
            if (s.cp_CardColor4 != '') {
                var elements = document.querySelectorAll("div[data-layout-item-name='cardDashboardItem5'] .dx-flex-card-layout");
                for (i = 0; i < elements.length; ++i) {
                    elements[i].style.backgroundColor = s.cp_CardColor4;
                }
            }
          
            var headers = document.getElementsByClassName("dx-dashboard-item-header")
            var fz = '<%= ttitulo%>';
            // alert(fz);
            if (fz != '') {
                for (i = 0; i < headers.length; i++) {
                    // if (headers[i].innerText.indexOf('Grid 1') != -1) {
                    // debugger;
                    // headers[i].style.fontSize = "40px";
                    // }
                }
            }


            }
            catch (err) {
            }

            
        }
    </script>


<script type="text/javascript">
    var dashboardGrids = {};

    function PerformExport(s, e) {
        // Define Dashboard Grid Item name to be exported...
        var gridToExport = comboBox.GetValue();
        //var hiddenMeasures = dashboardViewer['cp_' + gridToExport + '_HiddenMeasures'];
        //var itemData = GetDashboardItemData(dashboardViewer, gridToExport, hiddenMeasures);
        //if (!(typeof (dashboardGrids[gridToExport]) != 'undefined' && dashboardGrids[gridToExport] != null)) {
        try {
            ExportGrid(dashboardGrids[gridToExport], gridToExport);
        }
        catch(err) {
        }            
        //}
    }

    function ExportGrid(gridInstance, gridItemName) {
        var columnsSortOrder = [];
        var grid = gridInstance;
        if (grid.NAME == 'dxDataGrid') {
            for (var i = 0; i < grid.columnCount() ; i++) {
                var sortOrder = grid.columnOption(i, "sortOrder") ? grid.columnOption(i, "sortOrder") : 'none';
                columnsSortOrder.push(sortOrder);
            }
            document.getElementById('gridColumnSorting').value = columnsSortOrder;
            document.getElementById('exportname').value = gridItemName;
        }
        var itemData = GetDashboardItemData(dashboardViewer, gridItemName);
        __doPostBack('buttonExportItem', itemData);
    }

    function ConfigureChart(s, e) {
        
    }

    var timeoutHandle;
    function ClearTooltips() {
        // dashboarditemGroup
        var k = 1;
        //e.ItemName.substring(19, 20);
        
        //alert (k);
        if (k > 0) {
            var fzc = "<%= corletra_grupo%>";
            var fzzc = fzc.split(",");

            var fzbc = "<%= corfundo_grupo%>";
            var fzzbc = fzbc.split(",");
            
                var elements = $('span[class="dx-dashboard-item-header-text-caption"]').filter(function () { return ($(this).text() === 'Group 1') });
                for (i = 0; i < elements.length; ++i) {
                    if (fzzc[k - 1] != '') elements[i].style.color = fzzc[k - 1];
                    if (fzzbc[k - 1] != '') elements[i].style.backgroundColor = fzzbc[k - 1];
                    // if (fzzc[k - 1] != '') elements[i].style.alignment = 'center';                                                                
                    //elements[i].style.fontSize = '12px';
                    //elements[i].style.fontFamily = 'Arial';
                }
            
        }
    }

    function ItemWidgetCreatedHandle(s, e) {
        //alert(e.ItemName);
          
        dashboardGrids[e.ItemName] = e.GetWidget();

                clearTimeout(timeoutHandle);
                timeoutHandle = setTimeout(function () { ClearTooltips(); }, 100);
            

        var n = e.ItemName.indexOf("chartDashboardItem");
        if (e.ItemName.indexOf("pieDashboardItem") >= 0) {
            var data = s.GetItemData(e.ItemName);
            var chart = e.GetWidget();
            dashboardGrids[e.ItemName] = e.GetWidget();

            var k = e.ItemName.substring(16, 17);

                if (k > 0) {
                    var fzb = "<%= fbackcolorp%>";
                    var fzzb = fzb.split(",");
                    if (fzzb[k - 1] != '') {
                        $.each(chart, function (_, pie) {
                            pie.element().css({ backgroundColor: fzzb[k - 1] });
                        });
                    }


                    var fz = "<%= flsizep%>";
                    var fzz = fz.split(",");

                    var fz1 = s.cp_flabel;
                    var fzz1 = fz1.split(",");
                    
                    if (fzz[k - 1] != '') {
                        //alert(fzz[k - 1]);
                        var pie = e.GetWidget()[0];
                        pie.option("series[0]", {
                            label: { font: { size: parseInt(fzz[k - 1]) + 'px' } }
                        });

                        pie.option({
                            label: { font: { size: parseInt(fzz[k - 1]) + "px" } }
                        });

                    }
                    if (fzz1[k - 1] != '') {
                        //alert(fzz1[k - 1]);
                        var pie = e.GetWidget()[0];
                        pie.option("series[0]", {
                            label: { position: fzz1[k - 1] }
                        });

                    }

                }            
        }
       
        if (e.ItemName.indexOf("chartDashboardItem") >= 0) {
            dashboardGrids[e.ItemName] = e.GetWidget();
            var k = e.ItemName.substring(18, 19);
            if (k > 0) {
                var chart = e.GetWidget();
                dashboardGrids[e.ItemName] = e.GetWidget();

                var chartOptions = chart.option();
                chartOptions.valueAxis[0].valueMarginsEnabled = false;
                chart.option(chartOptions);

                var fz = "<%= fbackcolor %>";
                var fzz = fz.split(",");
                if (fzz[k - 1] != '') {
                    chart.element().css({ backgroundColor: fzz[k - 1] });
                }


                fz = "<%= flsize %>";
                fzz = fz.split(",");

                var fzp = "<%= flsizepo%>";
                var fzzp = fzp.split(",");

                if (fzz[k - 1] != '') {
                    var chartOptions = chart.option();

                    chart.option(chartOptions);

                    var series = chart.option("series");
                    $(series).each(function (i, item) {
                        if (item.label)
                            item.label.font = { size: parseInt(fzz[k - 1]) + 'px' };
                    });
                    chart.option("series", series);
                }

                if (fzzp[k - 1] != '') {
                    var chartOptions = chart.option();

                    chart.option(chartOptions);
                    chartOptions.valueAxis[0].label.font = { size: parseInt(fzz[k - 1]) + 'px' };
                    chart.option({
                        argumentAxis: { label: { font: { size: parseInt(fzz[k - 1]) + 'px' } } },
                    });

                }


                fz = "<%= flangle %>";
                fzz = fz.split(",");
                if (fzz[k - 1] != '') {
                    var chartOptions = chart.option();

                    chart.option(chartOptions);
                    chart.option({
                        argumentAxis: { label: { overlappingBehavior: { mode: 'rotate', rotationAngle: parseInt(fzz[k - 1]) } } }               
                    });
            }

                chart.option(chartOptions);
                fz = "<%= sobreporl%>";
                fzz = fz.split(",");
                if (fzz[k - 1] != '') {                    
                    chart.option({
                        resolveLabelOverlapping: fzz[k - 1]
                    });
                }
            
                var chartlab = "<%= chartlabel%>";
                var chartl = chartlab.split(",");

                var chartOptions = chart.option();
                for (var i = 0; i < chartl.length; i++) {
                    if (chartl[i] != '') {
                        var chartll = chartl[i].split("|");
                        for (var j = 0; j < chartll.length; j++) {
                            for (var x = 0; x < chart.series.length; x++) {
                                if (chartll[j] == chart.series[x].name) {
                                    chartOptions.series[x].label = { visible: false }
                                }
                            }
                        }

                    }
                }

                var chartlar = "<%= chartlargura%>";
                var chartla = chartlar.split(",");

                var chartlarn = "<%= chartlarguran%>";
                var chartlan = chartlarn.split(",");
                
                var chart = e.GetWidget();
                for (var x = 0; x < chart.series.length; x++) {
                    var seriesType = chartOptions.series[x].type;
                    if (seriesType == "line") {                                                                        
                        var chartla1 = chartla[k].split("|");
                        var chartla2 = chartlan[k].split("|");
                        for (var j = 0; j < chartla1.length; j++) {
                            if (chartla1[j] != '') {
                                if (chartla1[j] == chart.series[x].name) {                                    
                                    chartOptions.series[x].width = chartla2[j];
                                }
                            }
                        }
                    }
                }
                chart.option(chartOptions);

                var fl = '<% =flescala%>';
                var fll= fl.split(",");                
                var chartOptions = chart.option();                
                //alert(fl);

                if (fll[k - 1] != '' && typeof fll[k - 1] != 'undefined') {
                    //alert('max= ' + (k-1) + '/' + fll[k - 1]);
                    chart.option("valueAxis[0].max", fll[k-1]);
                    chart.option(chartOptions);
                }

                var flm = '<%= flescala_min%>';
                var flmm = flm.split(",");
                if (flmm[k - 1] != '' && typeof flmm[k - 1] != 'undefined') {
                    //alert('min= ' + flmm[k - 1]);
                    chart.option("valueAxis[0].min", flmm[k - 1]);
                    chart.option("valueAxis[0].showZero", false);                    
                    chart.option(chartOptions);
                }
            }                
            else {
                if (chart.length > 0) {
                    var k = e.ItemName.substring(16, 17);
                    if (k > 0) {
                        var fz = "<%= fbackcolorp %>";
                        var fzz = fz.split(",");
                        if (fz != '') {
                            chart[0].element().parents().eq(2).css({ backgroundColor: fzz[k - 1] });
                        }
                    }
                }
            }

        }

                    var n = e.ItemName.indexOf("gridDashboardItem");                    
                    if (n>=0) {
                        var grid = e.GetWidget();
                        dashboardGrids[e.ItemName] = e.GetWidget();                    

                        var k = e.ItemName.substring(17, 18);
                        var data = s.GetItemData(e.ItemName);
                        
                        var fct = "<%= temposcroll %>";
                        var fcct = fct.split(",");

                        if (fcct[k - 1] != '') {
                            grid.option({
                                onContentReady: function () {
                                    var scrollView = grid.getScrollable();
                                    var needScroll = true;
                                    var dist = 0;
                                    if (scrollView != null) {
                                        scrollView.on("scroll", function (e) {
                                            if (e.reachedBottom)
                                                needScroll = false;
                                        });
                                        setInterval(function () {
                                            if (needScroll) {
                                                scrollView.scrollBy(dist);
                                                dist++;
                                            }
                                        }, fcct[k-1]);
                                    }
                                }
                            })
                        }

                        var fc = "<%= falign %>";                                    
                        var fcc = fc.split(",");

                        var fifg1 = "<%= fifgalign%>";                                    
                        var fifg = fifg1.split(",");

                        var fig1 = "<%= figalign%>";                                    
                        var fig = fig1.split(",");
                                                
                        var gridOptions = grid.option();                        
                        var rccfont = "<%= rchcfonte %>";
                        var rcccfont = rccfont.split(",");

                        var rcc1font = "<%= rchfonte %>";
                        var rccc1font = rcc1font.split(",");

                        grid.option({
                            onCellPrepared: function (e) {
                                
                                var fzz1 = '<%= ntooltip%>'; //estcli;meu estado|nomven;meu grupo';
                                var fzz = fzz1.split("|");                                

                                if (e.rowType == 'header') {
                                    e.cellElement.mousemove(function () {
                                        var headerTitle = e.cellElement.children();
                                        if (fzz[k - 1] != '') {
                                            headerTitle.attr('title', fzz[k - 1]);
                                        }
                                    })
                                }
                            }
                        })

                        columns = grid.option('columns');
                        for (ki = 0; ki < columns.length; ki++) {                            
                            if (fifg[ki] != '') {
                                if (columns[ki].caption == fifg[ki]) {
                                    grid.columnOption(ki, 'alignment', fig[ki]);
                                }
                            }
                        }
                        
                        
                        grid.option({
                            onRowPrepared: function (info) {
                                if (info.rowType == "data") {      
                                    if (k>0) {          
                                        var fz = "<%= fsize %>";                                    
                                        var fzz = fz.split(",");
                                    
                                        var ccfont = "<%= ccfont %>";                                    
                                        var cccfont = ccfont.split(",");

                                        var fname = "<%= fname %>";                                    
                                        var ffname = fname.split(",");

                                        var fitalic  = "<%= ritalic %>";                                    
                                        var ffitalic = fitalic.split(",");

                                        var fbold  = "<%= rbold %>";                                    
                                        var ffbold = fbold.split(",");

                                        if (fz != ''  && fzz[k-1] != '0') { info.rowElement[0].style.fontSize = fzz[k - 1] + "px"; }
                                        if (ccfont != '') { info.rowElement[0].style.color = cccfont[k - 1]; }

                                        if (fname != '') { info.rowElement[0].style.fontFamily = ffname[k - 1]; }
                                        if (ffbold[k - 1] == 'True') { info.rowElement[0].style.fontWeight = "bold"; }


                                    }
                                }
                                else {
                                if (k>0) {          
                                    var fz = "<%= fsizeh %>";                                    
                                    var fzz = fz.split(",");
                                    
                                    var ccfont = "<%= chfont %>";                                    
                                    var cccfont = ccfont.split(",");

                                    var cchfont = "<%= chcfont%>";
                                    var ccchfont = cchfont.split(",");

                                    var fname = "<%= fnameh %>";                                    
                                    var ffname = fname.split(",");

                                    var fitalic  = "<%= hitalic %>";                                    
                                    var ffitalic = fitalic.split(",");

                                    var fbold  = "<%= hbold %>";                                    
                                    var ffbold = fbold.split(",");

                                    if (fz != '' && fzz[k-1] != '0') { info.rowElement[0].style.fontSize = fzz[k-1] + "px"; }
                                    if (ccfont != '') { info.rowElement[0].style.color = cccfont[k - 1]; }
                                    if (cchfont != '') { info.rowElement.css('background-color', ccchfont[k - 1]); }
                                    if (fname != '') { info.rowElement[0].style.fontFamily = ffname[k - 1]; }                                    
                                    if (ffbold[k - 1] == 'True') { info.rowElement[0].style.fontWeight = "bold"; }                                    
                                    }
                                }
                            },
                        });

                        if (fcc[k-1] != '') {
                            $(columns).each(function() {
                                this.alignment = fcc[k-1];
                            });
                            grid.option('columns', columns);
                        }

                        var hhe = "<%= hheight %>";
                        var hh = hhe.split(",");
                        
                        if (hhe != '' && hh[k - 1] != '0') {
                            var elements = document.querySelectorAll("div[data-layout-item-name='gridDashboardItem" + k + "'] .dx-header-row");
                            for (j = 0; i < elements.length; j++) {
                                elements[j].style.height = hh[k - 1];
                            }
                        }                        
               }                            

               var n = e.ItemName.indexOf("treemapDashboardItem");                    
               if (n >= 0) {
                   var treemap = e.GetWidget();
                   var k = e.ItemName.substring(20, 21);
                   var sombra = '<%= sombra%>';
                   var fzz = sombra.split(",");
                   if (fzz[k-1] == 'off') {                      
                       treemap.on("drawn", function (e) {
                           e.element.find("text").removeAttr("filter");
                       });
                   }
                   
                   if (s.cp_flsizef != ',') {
                       if (s.cp_flsizef === null) {
                       }
                       else {
                           var fon = s.cp_flsizef;
                           var fzz = fon.split(",");
                           // + "px";
                           // alert(fon);
                           if (fzz[k - 1] != '') {
                               treemap.option({
                                   tile: {
                                       label: {
                                           font: {
                                               size: fzz[k - 1] + 'px'
                                           }
                                       }
                                   },
                                   group: {
                                       label: {
                                           font: {
                                               size: fzz[k - 1] + 'px'
                                           }
                                       }
                                   }
                               });
                           }
                       }
                   }
               }

     var n = e.ItemName.indexOf("pivotDashboardItem");                    
     if (n >= 0) {
         dashboardGrids[e.ItemName] = e.GetWidget();

        var fz = "<%= fcolumn %>";                                    
        var fzz =   fz.split(",");

        var fc = "<%= palign %>";                                    
         var fcc = fc.split(",");

         var fic = "<%= fialign %>";
         var ficc = fic.split(",");

         var ficf = "<%= fifalign%>";
         var ficcf = ficf.split(",");

         var fzer = "<%= fzero%>";
         var fzerr = fzer.split(",");

        var sl = "<%= fshowl%>";                                    
        var showl = sl.split(",");   

        var sc = "<%= fshowc%>";                                    
        var showc = sc.split(",");   

        var pivot = e.GetWidget();

        var k = e.ItemName.substring(18, 19);
       
        pivot.option({
            wordWrapEnabled: false
        });

        if (showc[k - 1] != '') {
            //alert(showc[k - 1] = (showc[k - 1] === "true"));
            pivot.option('showColumnGrandTotals', showc[k - 1] = (showc[k - 1] === "true"));
            //debugger;
        }
        
        if (showl[k - 1] != '') {
            pivot.option('showRowGrandTotals', showl[k - 1] = (showl[k - 1] === "true"));
            //alert(showl[k - 1] = (showl[k - 1] === "true"));
        }
            
        if (fcc[k - 1] != '') {
        pivot.option({
            onCellPrepared: function (e) {
                e.cellElement.css("text-align", fcc[k - 1]);
            }
        });
        }
        

        var x = $("thead.dx-pivotgrid-horizontal-headers .dx-grandtotal:first").parent()
        x.remove()

        pivot.on("cellPrepared", function (e) {
            var dataField = e.component.getDataSource().getAreaFields("data")[e.cell.dataIndex];
            if (e.area == 'data') {
                //console.log(dataField.caption);
                //alert(ficc.length);
                for (var ki = 0; ki < ficc.length; ki++) {
                    if (ficc[ki] != '') {
                        if (dataField.caption == ficcf[ki]) {
                            e.cellElement.css("text-align", ficc[ki]);
                        }
                    }
                }
            }
        });
        pivot.getDataSource().reload();

        //alert("<%= fcoluna_fname%>"); 
        var defaultCellPrepared = pivot.option("onCellPrepared");
        pivot.option({
            onCellPrepared: function (e) {
                if (e.area === "column" && e.cell.type === "GT" && e.cell.dataIndex === undefined) {
                    e.cellElement.hide();
                }

                defaultCellPrepared(e);

                if (e.area == 'data' && e.cell.value === "") {
                    if (fzerr[k - 1] != '') { e.cellElement.text(fzerr[k - 1]) };
                    }

                if (e.area == "data") {                    
                    var f1 = "<%= fdados_fsize%>".split(",");
                    var f2 = "<%= fdados_fname%>".split(",");
                    var f3 = "<%= fdados_rbold%>".split(",");
                    var f4 = "<%= fdados_ritalic%>".split(",");
                    //debugger;
                    //alert(f1[k - 1]);
                    if (f1[k - 1] != '') e.cellElement.css("font-size", f1[k - 1] + "px");
                    if (f2[k - 1] != '') e.cellElement.css("font-family", f2[k - 1]);
                    if (f3[k - 1] != '') e.cellElement.css("font-weight", f3[k - 1]);                    
                };
                if (e.area == "column") {
                    var f1 = "<%= fcoluna_fsize%>".split(",");
                    var f2 = "<%= fcoluna_fname%>".split(",");
                    var f3 = "<%= fcoluna_rbold%>".split(",");
                    var f4 = "<%= fcoluna_ritalic%>".split(",");

                    if (f1[k - 1] != '') e.cellElement.css("font-size", f1[k - 1] + "px");
                    if (f2[k - 1] != '') e.cellElement.css("font-family", f2[k - 1]);
                    if (f3[k - 1] != '') e.cellElement.css("font-weight", f3[k - 1]);                    
                };
                if (e.area == "row") {
                    var f1 = "<%= flinha_fsize%>".split(",");
                    var f2 = "<%= flinha_fname%>".split(",");
                    var f3 = "<%= flinha_rbold%>".split(",");
                    var f4 = "<%= flinha_ritalic%>".split(",");

                    if (f1[k - 1] != '') e.cellElement.css("font-size", f1[k - 1] + "px");
                    if (f2[k - 1] != '') e.cellElement.css("font-family", f2[k - 1]);
                    if (f3[k - 1] != '') e.cellElement.css("font-weight", f3[k - 1]);                    
                };
                if (e.cell.rowType == 'GT' || e.cell.columnType == 'GT' || e.cell.rowType == 'T' || e.cell.columnType == 'T') {
                    if ("<%= ftotal_rbold%>" != '') e.cellElement.css({ 'font-weight': 'bold' });
                };
            }
        });
        pivot.repaint();

        var fields = pivot.option('dataSource.fields');
        $(fields).each(function() {
            for (var i = 0; i < fzz.length; i++) {
              var ffz = fzz[i].split(";");
              if (ffz[0]==this.caption) {
                  this.width = ffz[1] + "px";
              }
            }

        });
        pivot.option('dataSource.fields', fields);
        if (fz != '') {
            for (var i = 0; i < fzz.length; i++) {
                var ffz = fzz[i].split(";");
                if (ffz[0] != '') {
                    var Pivot = e.GetWidget();
                    Pivot.getDataSource().field(ffz[0], { width: ffz[1] + "px" });                    
                }
            }
            Pivot.getDataSource().reload();
        }
    }
           
        if (e.ItemName.indexOf('gauge') >= 0) {
            dashboardGrids[e.ItemName] = e.GetWidget();
                var k = e.ItemName.substring(18, 19);
                var gauges = e.GetWidget();

            try {
                if (gauges.length > 0) {
                    var gb = '<%= gbackcolor %>';
                    if (gb != '') {
                        gauges[0].element().parents().eq(2).css({ backgroundColor: gb });
                    }
                }
                adddlert("Welcome guest!");
            }
            catch(err) {
            }            
                        var esca = hf.Get("scala"+k);
                        
                        for (var i = 0; i < gauges.length; i++) {
                            var roundValue = (gauges[i].option("scale.endValue"));
                                //gauges[i].option("value"));

                            //gauges[i].option("scale", {
                              //  startValue: 0,
                              //  endValue: gauges[i].option("value"),
                            //    customTicks: [0, gauges[i].option("value")]
                            //});
                            
                            if (esca != undefined) {
                                if (esca != '') {
                                    var escaa = esca.split("|");
                                    for (var j = 0; j < escaa.length; j++) {
                                        var escala = escaa[j].split(",");
                                        if (escala.length == 4) {
                                            var range1 = escala[0];
                                            if (escala[3] == 'True') range1 = range1 * roundValue / 100;

                                            var range2 = escala[1];
                                            if (escala[3] == 'True') range2 = range2 * roundValue / 100;

                                            var cor = escala[2];
                                        }

                                        var robj = {};
                                        robj["startValue"] = range1;
                                        robj["endValue"] = range2;
                                        robj["color"] = cor;
                                        var cont = gauges[i].option('rangeContainer');
                                        if (cont == null)
                                            cont = { ranges: [] };
                                        cont.ranges.push(robj);
                                        gauges[i].option('rangeContainer', cont);
                                    }

                                }
                            }

                            gauges[i].option('valueIndicator', {
                                type: "rectangleNeedle",
                                color: "#9B870C"
                            });
                        }

                        var gauges = e.GetWidget();
                        $.each(gauges, function (_, gauge) {
                            gauge.option('indicator.text.font', {
                                size: 32
                            });
                        });

                    }
       }
    </script>

    <script type="text/javascript">
        var textSeparator = ";";
        var currentDropDown;
        function OnListBoxSelectionChanged(listBox, args) {
            UpdateText(currentDropDown, listBox);
        }

        function UpdateText(dropDownControl, checkBox) {
            var selectedItems = checkBox.GetSelectedItems();
            dropDownControl.SetText(GetSelectedItemsText(selectedItems));
        }

        function SynchronizeListBoxValuesResources(dropDown, args) {
            currentDropDown = dropDown;
            resourcesCheckListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(resourcesCheckListBox, texts);
            resourcesCheckListBox.SelectValues(values);
            UpdateText(dropDown, resourcesCheckListBox);
        }

        function SynchronizeListBoxValuesLocations(dropDown, args) {
            currentDropDown = dropDown;
            locationsCheckListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(locationsCheckListBox, texts);
            locationsCheckListBox.SelectValues(values);
            UpdateText(dropDown, locationsCheckListBox);
        }

        function SynchronizeListBoxValuesSubjects(dropDown, args) {
            currentDropDown = dropDown;
            subjectsCheckListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(subjectsCheckListBox, texts);
            subjectsCheckListBox.SelectValues(values);
            UpdateText(dropDown, subjectsCheckListBox);
        }


        function GetSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                texts.push(items[i].text);
            return texts.join(textSeparator);
        }

        function GetValuesByTexts(checkBox, texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = checkBox.FindItemByText(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;

        }

    </script>
       

<form id="form2" runat ="server" >     
    <div style="display: none;">
    <iframe id="MaintainSess" src="SessionAlive.aspx" width="0" height="0" runat="server"></iframe>
    </div> 

<dx:ASPxTimer ID="Timer1" runat="server"></dx:ASPxTimer>
<dx:ASPxTimer ID="Timer2" runat="server"></dx:ASPxTimer>

<table id="topMenu" runat ="server"  border="0" align="center" cellpadding="0" cellspacing="0" width="100%" style="height: 30px">
  <tr id="atu" runat ="server" visible = "false">
  <td align ="left">               
    <dx:ASPxButton ID="HyperLink1" ToolTip ="Voltar" runat="server" Text="Voltar" Visible ="false" Width ="50px"  NavigateUrl="Modulos_sair.aspx" OnClick ="buttonsair" >
		<Image Height="20px" Url="~/images/sair.png"></Image>					    
		</dx:ASPxButton> 
    <dx:ASPxButton ID="Button2" ToolTip ="Atualizar" runat="server" Text="Atualizar" Width="50px" Height ="31px">
        <Image Height="20px" Url="~/images/atualizar.png"></Image>
    </dx:ASPxButton>                    
    <asp:CheckBox ID="vexportar1" runat="server" Text="Exportar" ToolTip ="Exportar" Visible = "false" />
                    <dx:ASPxButton ID="bcomp" runat="server" Visible="false" AutoPostBack ="false" 
                        Style="vertical-align: middle" Text="" ToolTip="Compartilhar" Width="41px">
                        <Image Height="20px" Url="~/images/share.png"></Image>
                         <clientsideevents click = "compartilhar"></clientsideevents>
                    </dx:ASPxButton>                    
    </td> 
    <td width="10%" align="right" >
                <dx:ASPxLabel ID="ap11" align="right" Visible = "false" runat="server" Text ="Alternar projetos:" CssPostfix="DevEx"></dx:ASPxLabel>            
            </td> 
            <td width="5%">
                <dx:ASPxComboBox ID="ap22" runat="server" Visible = "false"  DropDownStyle ="DropDown" AutoPostBack ="true" OnButtonClick ="ap2_click" ValueType="System.String" Width="100px">    
                    </dx:ASPxComboBox>
                </td>

   <td align="right" >
    <dx:ASPxLabel ID="ASPxLabel7" align="right" width="150px" Visible = "false"  runat="server" Text ="Zoom:" CssPostfix="DevEx"></dx:ASPxLabel>            
       </td>
      <td>
   <dx:ASPxGridLookup ID="comboitems1" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1es1" AutoPostBack ="false" 
                Width="200px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">   
                    <ClientSideEvents QueryCloseUp="OnQueryCloseUp" />                                 
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close1a" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1es1" Width="100" />                               
                           </td>           
                            <td>
                            <dx:ASPxButton ID="Cancel1a" runat="server" AutoPostBack="false" Text="Cancelar" width="100"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1es1.RollbackToLastConfirmedSelection();
		                                    gridLookup1es1.HideDropDown();
		                                }" />
                                </td>                 
                            <td>
                                <dx:ASPxButton ID="restaurar" runat="server" AutoPostBack="true" Text="Restaurar Items" ClientSideEvents-Click="CloseGridLookup1es1" OnClick ="limpaitems" Width="100" />                               
                           </td>           
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
        </td>
  </tr>
  <tr runat ="server">
	<td align="left"  bgcolor="#ffffff" width="15%" runat="server" id="ladoesq">
	<table runat="server" width="100%" border="0" align="left" cellpadding="0" cellspacing="0" id="topo">
		<tr>
		<td align="left" width="80px"  bgcolor="#ffffff">
		<dx:ASPxImage ID="ASPxImage1" runat="server"></dx:ASPxImage>
		</td> 
		<td align="left" width="100%" >				
        <table width = "100%"  >            
            <tr>
            <td width="30%"  bgcolor="silver">
		        <dx:ASPxMenu  BorderBetweenItemAndSubMenu="HideRootOnly" 
				EnableClientSideAPI="True" EnableViewState="False" 
				ID="ASPxMenu2" ItemAutoWidth="False" ItemSpacing="20px" runat="server" 
				ShowPopOutImages="True" Width="100%" bgcolor="silver" CssClass ="xtextbox"   >
		        <Items>
				    <dx:MenuItem Name="cenarios" Text="Voltar" NavigateUrl="Modulos_sair.aspx">
					    <Image Height="20px" Url="~/images/sair.png"></Image>					    
				    </dx:MenuItem>

                <dx:MenuItem Name="item" Text="Atualizar"><Template>
				<dx:ASPxButton ID="buttonSaveAs" runat="server" AutoPostBack ="true" Style="vertical-align: middle;"
						  Text="Atualizar" ToolTip="Atualizar Agora" Width="51px" OnClick="atualiza"  >
                    <Image Height="20px" Url="~/images/atualizar.png"></Image>
				</dx:ASPxButton>
                    </Template> 
                    </dx:MenuItem> 

                    <dx:MenuItem Name="bitem" Text="Compartilhar"><Template>
                    <dx:ASPxButton ID="bcompartilhar" runat="server" Visible="false" AutoPostBack ="false" 
                        Style="vertical-align: middle" Text="" ToolTip="Compartilhar" Width="41px">
                        <Image Height="20px" Url="~/images/share.png"></Image>
                         <clientsideevents click = "compartilhar"></clientsideevents>
                    </dx:ASPxButton>                    
                </template>
                </dx:MenuItem> 
		</Items> 			
		</dx:ASPxMenu>
</td>

<td width="25%" style="font-size: x-small; font-style: normal; font-family: Verdana;" bgcolor="silver" id="tempoa" runat ="server">
    <table  >
        <tr>
            <td width="5%">
<dx:ASPxLabel ID="ASPxLabel5" runat="server" Text ="Tempo de Atualização: "></dx:ASPxLabel>            
                </td> 
            <td>
<dx:ASPxComboBox ID="DropdownList1" runat="server" DropDownStyle ="DropDown" CssClass ="xtextbox" ValueType="System.String" Width="100px" ></dx:ASPxComboBox>     
                </td> 
            </tr> 
            </table> 
</td>
<td width="56%" style="font-size: x-small; font-style: normal; font-family: Verdana;" bgcolor="silver">    
    <table>
        <tr>
            <td>
    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text ="Rodízio em(seg): "></dx:ASPxLabel>            
            </td> 
            <td>
    <asp:TextBox ID="TextBox1" runat="server" Width="50" CssClass ="xtextbox"></asp:TextBox>
                </td> 
            <td>
    <dx:ASPxButton ID="Button1" ToolTip ="Aplicar" runat="server" Text="Aplicar" Image-Height ="15px" CssClass ="xtextbox"></dx:ASPxButton>                       
                </td> 
            <td>
    <dx:ASPxLabel ID="ASPxLabel6" Visible = "false"  runat="server" Text ="Exportar customizado:" CssPostfix="DevEx"></dx:ASPxLabel>            
                </td> 
            <td>
    <dx:ASPxComboBox ID="combogrades" runat="server" Visible = "false"  DropDownStyle ="DropDown" AutoPostBack ="false" OnButtonClick ="aspxbutton1_click" ClientInstanceName="comboBox" ValueType="System.String" Width="100px">    
        <ClientSideEvents SelectedIndexChanged  ="PerformExport" />
	</dx:ASPxComboBox>
                </td>
            <td>
                <dx:ASPxLabel ID="ap1" Visible = "false"  runat="server" Text ="Alternar projetos:" CssPostfix="DevEx"></dx:ASPxLabel>            
            </td> 
            <td>
                <dx:ASPxComboBox ID="ap2" runat="server" Visible = "false"  DropDownStyle ="DropDown" AutoPostBack ="true" OnButtonClick ="ap2_click" ValueType="System.String" Width="100px">    
                    </dx:ASPxComboBox>
                </td>
            <td align ="right" width="150px">
    <dx:ASPxLabel ID="ASPxLabel8" Visible = "false"  runat="server" Text ="Zoom:" CssPostfix="DevEx"></dx:ASPxLabel>            
                </td>
            <td>
            <dx:ASPxGridLookup ID="comboitems" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1es" AutoPostBack ="false" 
                Width="150px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">   
                    <ClientSideEvents QueryCloseUp="OnQueryCloseUp" />                                 
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                           <td>
                                <dx:ASPxButton ID="Close1" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1es" Width="130" />                               
                           </td>           
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="100"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1.RollbackToLastConfirmedSelection();
		                                    gridLookup1.HideDropDown();
		                                }" />
                                </td>                 
                            <td>
                                <dx:ASPxButton ID="restaurar" runat="server" AutoPostBack="true" Text="Restaurar Items" ClientSideEvents-Click="CloseGridLookup1es" OnClick ="limpaitems" Width="100" />                               
                           </td>           
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>

                </td>
                <td>
                <dx:ASPxLabel ID="ASPxLabel3" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>     
                </td>
                <td>       
			        <dx:ASPxComboBox ID="comboseries" runat="server" Visible = "false"  DropDownStyle ="DropDown" AutoPostBack ="true"  ValueType="System.String" Width="100px"></dx:ASPxComboBox>                
                </td> 

                <td>
                    <asp:CheckBox ID="vexportar" runat="server" Text="Exportar" ToolTip ="Exportar" Visible = "false" />                
                </td> 
            </tr> 
        </table> 
    </td>
        <td align="right" width="100%"  bgcolor="#ffffff">
            <img title="<%# info%>" src="images/info.png" alt="" width="30px" height="30px" />
    </td> 

</tr>
               <tr >
                <td width ="100%">
                    <div align = "right" >
                        <dx:ASPxLabel ID="lmsgbox" runat="server" Font-Bold="True" Font-Size="X-Small"  EnableClientSideAPI ="true" ClientIDMode ="Static" ForeColor="#000066"></dx:ASPxLabel>    	
                    </div> 
                </td>
                </tr>

</table>
		</td> 
		</tr> 
    </table>
    </td>
    </tr>           

	    <tr id="datas" runat="server" cssclass="xtextbox" >               
		<td id="corfiltro" width="100%" align ="left" runat="server" colspan ="2">
			<div align ="left" >
			<dx:ASPxLabel ID="label2" runat="server" 
				CssPostfix="DevEx" Font-Names="arial" Font-Size="X-Large">
			</dx:ASPxLabel>
            </div>

            <table width="100%" style="font-size: x-small; font-style: normal; font-family: Verdana;">
            <tr>
            <td width= "4%">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text ="Data Inicial:" CssPostfix="DevEx"></dx:ASPxLabel>
                <dx:ASPxComboBox ID="dt1" runat="server" DropDownStyle ="DropDown"  ValueType="System.String" Width="100px"></dx:ASPxComboBox>     
                <dx:ASPxDateEdit runat = "server" ID="pick1" Visible="False" EnableViewState ="true" DateRangeSettings-CalendarColumnCount="1" width="100">
                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                            <RequiredField IsRequired="True" ErrorText="Data inicial requerida."></RequiredField>
                    </ValidationSettings>
                    <ClientSideEvents LostFocus="function(s,e){ if(!s.GetIsValid()) s.Focus(); }" />
                </dx:ASPxDateEdit>
            </td> 
            <td width="4%">
			    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text ="Data Final:" CssPostfix="DevEx"></dx:ASPxLabel>            
			    <dx:ASPxComboBox ID="dt2" runat="server" DropDownStyle ="DropDown"  ValueType="System.String" Width="100px"></dx:ASPxComboBox>
                <dx:ASPxDateEdit runat = "server" ID="pick2" Visible="False" EnableViewState ="true"  DateRangeSettings-CalendarColumnCount="1" Width="100" >
                    <DateRangeSettings StartDateEditID="pick1" />
                    <ValidationSettings Display="Dynamic" SetFocusOnError="True" CausesValidation="True" ErrorDisplayMode="ImageWithTooltip">
                        <RequiredField IsRequired="True" ErrorText="Data final requerida."></RequiredField>
                    </ValidationSettings>
                    <ClientSideEvents LostFocus="function(s,e){ if(!s.GetIsValid()) s.Focus(); }" />
                </dx:ASPxDateEdit>
            </td> 
            <td width="7%">
                <dx:ASPxLabel ID="tfiltro" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
                <dx:ASPxGridLookup ID="tfiltro1" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">   
                    <ClientSideEvents QueryCloseUp="OnQueryCloseUp" />                                 
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close1" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1" Width="200" />                               
                           </td>           
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1.RollbackToLastConfirmedSelection();
		                                    gridLookup1.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td> 
            <td width="7%">			
            <dx:ASPxLabel ID="tfiltroa" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
            <dx:ASPxGridLookup ID="tfiltro1a" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1a" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">                
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1a" />
                            </td>
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1a.RollbackToLastConfirmedSelection();
		                                    gridLookup1a.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td>
            <td width="7%">
                <dx:ASPxLabel ID="tfiltrob" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
    <dx:ASPxGridLookup ID="tfiltro1b" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1b" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">                
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1b" />
                            </td>
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1b.RollbackToLastConfirmedSelection();
		                                    gridLookup1b.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td>
            <td width="7%">      
                <dx:ASPxLabel ID="tfiltroc" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
            <dx:ASPxGridLookup ID="tfiltro1c" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1c" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">                
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1c" />
                            </td>
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1c.RollbackToLastConfirmedSelection();
		                                    gridLookup1c.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td> 
            <td  width="7%">
                <dx:ASPxLabel ID="tfiltrod" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
            <dx:ASPxGridLookup ID="tfiltro1d" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1d" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">                
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1d" />
                            </td>
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1d.RollbackToLastConfirmedSelection();
		                                    gridLookup1d.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td>
                
            <td  width="7%">			
                <dx:ASPxLabel ID="tfiltroe" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
            <dx:ASPxGridLookup ID="tfiltro1e" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1e" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">                
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1e" />
                            </td>
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1e.RollbackToLastConfirmedSelection();
		                                    gridLookup1e.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td> 
            <td  width="7%">
                <dx:ASPxLabel ID="tfiltrof" Visible = "false"  runat="server" Text ="Séries:" CssPostfix="DevEx"></dx:ASPxLabel>            
            <dx:ASPxGridLookup ID="tfiltro1f" runat="server" SelectionMode="Multiple" ClientInstanceName="gridLookup1f" AutoPostBack ="false" 
                Width="100px" TextFormatString="{0}" MultiTextSeparator=", " Caption="" Visible ="false">                
        <GridViewProperties>           
            <Templates>
                <StatusBar>
                    <table class="OptionsTable" style="float: right">
                        <tr>
                            <td>
                                <dx:ASPxButton ID="Close" runat="server" AutoPostBack="true" Text="Aplicar" ClientSideEvents-Click="CloseGridLookup1f" />
                            </td>
                            <td>
                            <dx:ASPxButton ID="Cancel" runat="server" AutoPostBack="false" Text="Cancelar" width="130"
		                                ClientSideEvents-Click="function(s, e) {
		                                    gridLookup1f.RollbackToLastConfirmedSelection();
		                                    gridLookup1f.HideDropDown();
		                                }" />
                                </td>                 
                        </tr>
                    </table>
                </StatusBar>
            </Templates>
            <Settings ShowFilterRow="True" ShowStatusBar="Visible" />
        </GridViewProperties>
    </dx:ASPxGridLookup>
            </td> 
            <td  width="7%">
                <dx:ASPxLabel ID="Label3" runat="server" Text ="Data Final:" CssPostfix="DevEx" Visible="False"  ></dx:ASPxLabel>
                <dx:aspxtextbox ID="textbox1x" runat="server" Visible="False"  Width="100%" AutoPostBack="false" ClientInstanceName ="textbox1x" ></dx:aspxtextbox>
                </td>
                <td>
                <dx:ASPxButton ID="scanBarCode" runat="server" Visible="false" AutoPostBack ="false" 
                        Style="vertical-align: middle" Text="" ToolTip="Cod Barras" Width="41px">
                        <Image Height="20px" Url="~/images/qrcodeCodigoBarras.png"></Image>
                         <clientsideevents click = "scanBarCode"></clientsideevents>
                </dx:ASPxButton>
            </td> 
            <td  width="7%">			
                <dx:ASPxLabel ID="label4" runat="server" Text ="Data Final:" CssPostfix="DevEx" Visible="False"  ></dx:ASPxLabel>
                <dx:aspxtextbox ID="textbox2x" runat="server" Visible="False"  Width="100%" AutoPostBack="false" ></dx:aspxtextbox>
            </td> 
            </tr> 
            </table> 

            </td>       
            </tr> 
		</table> 
    

            <img id="mostrar" runat="server"  align="right" style="display: none; height: 20px; width: 20px" src="images/arrow_collapse_down.gif" alt="Compacta" />
            <img id="esconder" runat = "server"  align="right" src="images/arrow_collapse_up.gif" alt="Expande" style="height: 20px; width: 20px" />
            <input id="gridColumnSorting" type="hidden" runat="server" />
            <input id="heightp" type="hidden" runat="server" />
            <input id="exportname" type="hidden" runat="server" />
            <input id="linkc" type="hidden" runat="server" />
            <input id="linkc1" type="hidden" runat="server" />

     <script type="text/javascript" >
         var mostrandoStr = Cookies.get("mostrando");
         var mostrando = true;

         if (mostrandoStr === "false")
             mudar();

         function mudar() {
             if (!mostrando) {
                 $("#mostrar").hide();
                 $("#topMenu").slideDown(300);
                 $("#esconder").show();

                 $('[id^="tabpage_"]').each(function (i, obj) {
                     var position = $(this).offset();
                     var off = $("#topMenu").height();
                     var x = position.top + off;
                     $(this).css({ 'top': x + 'px' });
                 })

                 mostrando = true;
                 Cookies.set("mostrando", "true");
             }
             else {
                 $("#esconder").hide();
                 var off = $("#topMenu").height();                 
                 $("#topMenu").slideUp(300);
                 $("#mostrar").show();

                 $('[id^="tabpage_"]').each(function (i, obj) {
                     var position = $(this).offset();
                     var x = position.top - off;
                     $(this).css({ 'top': x + 'px' });
                 })

                 mostrando = false;
                 Cookies.set("mostrando", "false");
             }
         }
         $("#esconder").click(function () {
             mudar();
         });
         $("#mostrar").click(function () {
             mudar();
         });

    </script>
         
    <table style="height: 30px" border="0" align="center" cellpadding="0" cellspacing="0" runat ="server" id="tbw" >
	<tr>
		<td align="center" colspan="4">
                
		<table border="0" align="center" cellpadding="0" cellspacing="0" runat="server" id="tbw1">
		<tr>
		<td align="center" bgcolor="#ffffff">		       
             
			<dx:ASPxPageControl ID="tabpage" runat="server" AutoPostBack ="true" EnableCallBacks ="true" ClientInstanceName ="pc" 
				Height="500px" TabSpacing="0px" EnableViewState ="true" TabStyle-Wrap ="True"  
                ShowVerticalScrollBar="True" VerticalScrollableHeight="800" Width ="100%"
                ShowHorizontalScrollBar="True" VerticalScrollBarStyle="Standard">                
				<TabPages>
					<dx:TabPage Text="Pagina 1" name="pg1">
						<ContentCollection>
							<dx:ContentControl runat="server" Height ="100%" SupportsDisabledAttribute="True" ID="pg1c" BackColor ="Black">    
                            <div style="overflow:auto; height:200px; width:auto;" runat="server" id="dtab1">                         
							    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                 
                            </div>        
                        </dx:ContentControl>
						</ContentCollection>
					</dx:TabPage>
				 </TabPages>				
                <Paddings Padding="2px" PaddingLeft="5px" PaddingRight="5px" />                
				<TabStyle Wrap="True"  Font-Names ="Verdana" Font-Size ="Medium"  Width="250px">
				</TabStyle>
				<ContentStyle>
					<Paddings Padding="12px" />
					<Border BorderColor="#484848" BorderStyle="Solid" BorderWidth="1px" />
				</ContentStyle>
				<Border BorderStyle="None" />                
                <ClientSideEvents Init="OnInit" />
			</dx:ASPxPageControl>
            <dx:ASPxHiddenField ID="ASPxHiddenField2" runat="server" ClientInstanceName="hf"></dx:ASPxHiddenField> 
            <dx:ASPxPopupControl ID="pcHint" runat="server" ClientInstanceName="ASPxPopupControl1"
                    EnableClientSideAPI="True" ShowCloseButton="True" ToolTip="tooltip" >
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>                
		<br />
	</td>

	</tr> 
	</table> 

	</td> 
<td>

</td>

	</tr> 

	</table> 

        <asp:ObjectDataSource ID="ObjectDataSourceResources" runat="server"
            SelectMethod="SelectMethodHandler" TypeName="BIWeb.CustomResourceDataSource"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceAppointment" runat="server"
            OnObjectCreated="ObjectDataSourceAppointment_ObjectCreated"
            SelectMethod="SelectMethodHandler"
            TypeName="BIWeb.CustomAppointmentDataSource"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceLocations" runat="server"
            OnObjectCreated="ObjectDataSourceLocations_ObjectCreated"
            SelectMethod="SelectMethodHandler"
            TypeName="BIWeb.CustomLocationsDataSource"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceSubjects" runat="server"
            OnObjectCreated="ObjectDataSourceSubjects_ObjectCreated"
            SelectMethod="SelectMethodHandler"
            TypeName="BIWeb.CustomSubjectsDataSource"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSourceResourcesDD" runat="server"
            OnObjectCreated="ObjectDataSourceResourcesDD_ObjectCreated"
            SelectMethod="SelectMethodHandler"
            TypeName="BIWeb.CustomResourceDDDataSource"></asp:ObjectDataSource>


</form>


</body>
</html>
