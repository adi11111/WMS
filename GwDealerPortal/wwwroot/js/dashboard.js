/*
 * Author: Abdullah A Almsaeed
 * Date: 4 Jan 2014
 * Description:
 *      This is a demo file used only for the main dashboard (index.html)
 **/

$(function () {

  'use strict';

  // Make the dashboard widgets sortable Using jquery UI
  $('.connectedSortable').sortable({
    placeholder         : 'sort-highlight',
    connectWith         : '.connectedSortable',
    handle              : '.box-header, .nav-tabs',
    forcePlaceholderSize: true,
    zIndex              : 999999
  });
  $('.connectedSortable .box-header, .connectedSortable .nav-tabs-custom').css('cursor', 'move');

  // jQuery UI sortable for the todo list
  $('.todo-list').sortable({
    placeholder         : 'sort-highlight',
    handle              : '.handle',
    forcePlaceholderSize: true,
    zIndex              : 999999
  });

  // bootstrap WYSIHTML5 - text editor
  //$('.textarea').wysihtml5();

  //$('.daterange').daterangepicker({
  //  ranges   : {
  //    'Today'       : [moment(), moment()],
  //    'Yesterday'   : [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
  //    'Last 7 Days' : [moment().subtract(6, 'days'), moment()],
  //    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
  //    'This Month'  : [moment().startOf('month'), moment().endOf('month')],
  //    'Last Month'  : [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
  //  },
  //  startDate: moment().subtract(29, 'days'),
  //  endDate  : moment()
  //}, function (start, end) {
  //  window.alert('You chose: ' + start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
  //});

  /* jQueryKnob */
  //$('.knob').knob();

  // jvectormap data
  var visitorsData = {
    US: 398, // USA
    SA: 400, // Saudi Arabia
    CA: 1000, // Canada
    DE: 500, // Germany
    FR: 760, // France
    CN: 300, // China
    AU: 700, // Australia
    BR: 600, // Brazil
    IN: 800, // India
    GB: 320, // Great Britain
    RU: 3000 // Russia
  };
  // World map by jvectormap
  //$('#world-map').vectorMap({
  //  map              : 'world_mill_en',
  //  backgroundColor  : 'transparent',
  //  regionStyle      : {
  //    initial: {
  //      fill            : '#e4e4e4',
  //      'fill-opacity'  : 1,
  //      stroke          : 'none',
  //      'stroke-width'  : 0,
  //      'stroke-opacity': 1
  //    }
  //  },
  //  series           : {
  //    regions: [
  //      {
  //        values           : visitorsData,
  //        scale            : ['#92c1dc', '#ebf4f9'],
  //        normalizeFunction: 'polynomial'
  //      }
  //    ]
  //  },
  //  onRegionLabelShow: function (e, el, code) {
  //    if (typeof visitorsData[code] != 'undefined')
  //      el.html(el.html() + ': ' + visitorsData[code] + ' new visitors');
  //  }
  //});

  // Sparkline charts
  var myvalues = [1000, 1200, 920, 927, 931, 1027, 819, 930, 1021];
  //$('#sparkline-1').sparkline(myvalues, {
  //  type     : 'line',
  //  lineColor: '#92c1dc',
  //  fillColor: '#ebf4f9',
  //  height   : '50',
  //  width    : '80'
  //});
  //myvalues = [515, 519, 520, 522, 652, 810, 370, 627, 319, 630, 921];
  //$('#sparkline-2').sparkline(myvalues, {
  //  type     : 'line',
  //  lineColor: '#92c1dc',
  //  fillColor: '#ebf4f9',
  //  height   : '50',
  //  width    : '80'
  //});
  //myvalues = [15, 19, 20, 22, 33, 27, 31, 27, 19, 30, 21];
  //$('#sparkline-3').sparkline(myvalues, {
  //  type     : 'line',
  //  lineColor: '#92c1dc',
  //  fillColor: '#ebf4f9',
  //  height   : '50',
  //  width    : '80'
  //});

  // The Calender
  $('#calendar').datepicker();

  // SLIMSCROLL FOR CHAT WIDGET
  //$('#chat-box').slimScroll({
  //  height: '250px'
  //});

  /* Morris.js Charts */
  // Sales chart
  //var area = new Morris.Area({
  //  element   : 'revenue-chart',
  //  resize    : true,
  //  data      : [
  //    { y: 'January', item1: 2666, item2: 4666, item3: 2666  },
  //    { y: 'February', item1: 2778, item2: 4294, item3: 2294  },
  //    { y: 'March', item1: 4912, item2: 4969, item3: 1969  },
  //    { y: 'April', item1: 3767, item2: 4597, item3: 3597  },
  //    { y: 'May', item1: 6810, item2: 5914, item3: 1914  },
  //    { y: 'June', item1: 5670, item2: 5293, item3: 4293  },
  //    { y: 'July', item1: 4820, item2: 6795, item3: 3795  },
  //    { y: 'August', item1: 15073, item2: 6963, item3: 59677 },
  //    { y: 'September', item1: 10687, item2: 7467, item3: 44600 },
  //    { y: 'October', item1: 8432, item2: 7713, item3: 5713  },
  //    { y: 'November', item1: 10687, item2: 7467, item3: 44600 },
  //    { y: 'December', item1: 10687, item2: 7467, item3: 44600 },
  //  ],
  //  xkey      : 'y',
  //  ykeys     : ['item1', 'item2', 'item3'],
  //  labels    : ['Item 1', 'Item 2', 'Item 3'],
  //  lineColors: ['#a0d0e0', '#3c8dbc', '#4c8dbc'],
  //  hideHover : 'auto'
  //});
  //var line = new Morris.Line({
  //  element          : 'line-chart',
  //  resize           : true,
  //  data             : [
  //    { y: '2011 Q1', item1: 2666 },
  //    { y: '2011 Q2', item1: 2778 },
  //    { y: '2011 Q3', item1: 4912 },
  //    { y: '2011 Q4', item1: 3767 },
  //    { y: '2012 Q1', item1: 6810 },
  //    { y: '2012 Q2', item1: 5670 },
  //    { y: '2012 Q3', item1: 4820 },
  //    { y: '2012 Q4', item1: 15073 },
  //    { y: '2013 Q1', item1: 10687 },
  //    { y: '2013 Q2', item1: 8432 }
  //  ],
  //  xkey             : 'y',
  //  ykeys            : ['item1'],
  //  labels           : ['Item 1'],
  //  lineColors       : ['#efefef'],
  //  lineWidth        : 2,
  //  hideHover        : 'auto',
  //  gridTextColor    : '#fff',
  //  gridStrokeWidth  : 0.4,
  //  pointSize        : 4,
  //  pointStrokeColors: ['#efefef'],
  //  gridLineColor    : '#efefef',
  //  gridTextFamily   : 'Open Sans',
  //  gridTextSize     : 10
  //});

  // Donut Chart
  //var donut = new Morris.Donut({
  //  element  : 'sales-chart',
  //  resize   : true,
  //  colors   : ['#3c8dbc', '#f56954', '#00a65a'],
  //  data     : [
  //    { label: 'Download Sales', value: 12 },
  //    { label: 'In-Store Sales', value: 30 },
  //    { label: 'Mail-Order Sales', value: 20 }
  //  ],
  //  hideHover: 'auto'
  //});



  //new Chart(ctx, config);









  // Fix for charts under tabs
  $('.box ul.nav a').on('shown.bs.tab', function () {
    area.redraw();
    donut.redraw();
    line.redraw();
  });



  /* The todo list plugin */
  //$('.todo-list').todoList({
  //  onCheck  : function () {
  //    window.console.log($(this), 'The element has been checked');
  //  },
  //  onUnCheck: function () {
  //    window.console.log($(this), 'The element has been unchecked');
  //  }
  //});




  // -------------
  // - PIE CHART -
  // -------------
  // Get context with jQuery - using jQuery's .get() method.
  //var modelPieChartCanvas = $('#pcModels').get(0).getContext('2d');
  //var pieChartModels = new Chart(modelPieChartCanvas); 

  //var faultPieChartCanvas = $('#pcFaults').get(0).getContext('2d');
  //var pieChartFaults = new Chart(faultPieChartCanvas);
  //var ModelPieData = [
  //    {
  //        value: 700,
  //        color: '#f56954',
  //        highlight: '#f56954',
  //        label: 'Chrome',
  //        labelColor: 'white',
  //        labelFontSize: '16'
  //    },
  //    {
  //        value: 500,
  //        color: '#00a65a',
  //        highlight: '#00a65a',
  //        label: 'IE'
  //    },
  //    {
  //        value: 400,
  //        color: '#f39c12',
  //        highlight: '#f39c12',
  //        label: 'FireFox'
  //    },
  //    {
  //        value: 600,
  //        color: '#00c0ef',
  //        highlight: '#00c0ef',
  //        label: 'Safari'
  //    },
  //    {
  //        value: 300,
  //        color: '#3c8dbc',
  //        highlight: '#3c8dbc',
  //        label: 'Opera'
  //    },
  //    {
  //        value: 100,
  //        color: '#d2d6de',
  //        highlight: '#d2d6de',
  //        label: 'Navigator'
  //    }
  //];
  //var FaultPieData = [
  //    {
  //        value: 700,
  //        color: '#f56954',
  //        highlight: '#f56954',
  //        label: 'Chrome',
  //        labelColor: 'white',
  //        labelFontSize: '16'
  //    },
  //    {
  //        value: 500,
  //        color: '#00a65a',
  //        highlight: '#00a65a',
  //        label: 'IE'
  //    },
  //    {
  //        value: 400,
  //        color: '#f39c12',
  //        highlight: '#f39c12',
  //        label: 'FireFox'
  //    },
  //    {
  //        value: 600,
  //        color: '#00c0ef',
  //        highlight: '#00c0ef',
  //        label: 'Safari'
  //    },
  //    {
  //        value: 300,
  //        color: '#3c8dbc',
  //        highlight: '#3c8dbc',
  //        label: 'Opera'
  //    },
  //    {
  //        value: 100,
  //        color: '#d2d6de',
  //        highlight: '#d2d6de',
  //        label: 'Navigator'
  //    }
  //];
  //var PieOptions = {
  //    // Boolean - Whether we should show a stroke on each segment
  //    segmentShowStroke: true,
  //    // String - The colour of each segment stroke
  //    segmentStrokeColor: '#fff',
  //    // Number - The width of each segment stroke
  //    segmentStrokeWidth: 1,
  //    // Number - The percentage of the chart that we cut out of the middle
  //    percentageInnerCutout: 50, // This is 0 for Pie charts
  //    // Number - Amount of animation steps
  //    animationSteps: 100,
  //    // String - Animation easing effect
  //    animationEasing: 'easeOutBounce',
  //    // Boolean - Whether we animate the rotation of the Doughnut
  //    animateRotate: true,
  //    // Boolean - Whether we animate scaling the Doughnut from the centre
  //    animateScale: false,
  //    // Boolean - whether to make the chart responsive to window resizing
  //    responsive: true,
  //    // Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
  //    maintainAspectRatio: false,
  //    // String - A legend template
  //    legendTemplate: '<ul class=\'<%=name.toLowerCase()%>-legend\'><% for (var i=0; i<segments.length; i++){%><li><span style=\'background-color:<%=segments[i].fillColor%>\'></span><%if(segments[i].label){%><%=segments[i].label%><%}%></li><%}%></ul>',
  //    // String - A tooltip template
  //    tooltipTemplate: '<%=value %> <%=label%> users'
  //};
  //// Create pie or douhnut chart
  //// You can switch between pie and douhnut using the method below.
  //pieChartModels.Doughnut(ModelPieData, PieOptions);
  //pieChartFaults.Doughnut(FaultPieData, PieOptions);
  // -----------------
  // - END PIE CHART -
  // -----------------









  /*
   * DONUT CHART
   * -----------
   */

  var donutData = [
      { label: 'Series2', data: 30, color: '#3c8dbc' },
      { label: 'Series3', data: 20, color: '#0073b7' },
      { label: 'Series4', data: 50, color: '#00c0ef' }
  ]
  //new Plot($('#pcFaults'), donutData, {
  //    series: {
  //        pie: {
  //            show: true,
  //            radius: 1,
  //            innerRadius: 0.5,
  //            label: {
  //                show: true,
  //                radius: 2 / 3,
  //                formatter: labelFormatter,
  //                threshold: 0.1
  //            }

  //        }
  //    },
  //    legend: {
  //        show: false
  //    }
  //},[]);
  //$(document).ready(function () {
  //    $.plot('#pcFaults', donutData, {
  //        series: {
  //            pie: {
  //                show: true,
  //                radius: 1,
  //                innerRadius: 0.5,
  //                label: {
  //                    show: true,
  //                    radius: 2 / 3,
  //                    formatter: labelFormatter,
  //                    threshold: 0.1
  //                }

  //            }
  //        },
  //        legend: {
  //            show: false
  //        }
  //    });
  //});

    /*
     * END DONUT CHART
     */


  /*
* Custom Label formatter
* ----------------------
*/
  function labelFormatter(label, series) {
      return '<div style="font-size:13px; text-align:center; padding:2px; color: #fff; font-weight: 600;">'
          + label
          + '<br>'
          + Math.round(series.percent) + '%</div>'
  }


 

});
