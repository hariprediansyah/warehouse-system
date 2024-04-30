$(function () {
  "use strict";
  Highcharts.chart("outstandingEJTest", {
    // chart: {
    //   plotBackgroundColor: null,
    //   plotBorderWidth: null,
    //   plotShadow: false,
    //   type: "pie",
    //   styledMode: true,
    // },
    credits: {
      enabled: false,
    },
    title: {
      text: null,
    },
    tooltip: {
      pointFormat:
        "{series.name}: <b>{point.percentage:.1f}% | (Jumlah: {point.z}</b>",
    },
    accessibility: {
      point: {
        valueSuffix: "%",
      },
    },
    plotOptions: {
      pie: {
        allowPointSelect: true,
        cursor: "pointer",
        // dataLabels: {
        //   enabled: true,
        //   format: "<b>{point.name}</b>: {point.y}% (Jumlah: {point.z})",
        // },
      },
    },
    series: [
      {
        type: "pie",
        name: "Outstanding EJ",
        colorByPoint: true,
        dataLabels: {
          // enabled: true,
          format: "<b>{point.name}</b>: {point.y}% (Jumlah: {point.z})",
          style: {
            fontSize: 13,
          },
        },
        data: [
          {
            name: "OS EJ CR (Selisih)",
            y: 2.6,
            z: 586,
          },
          {
            name: "EJ Sistem Bank",
            y: 19.58,
            z: 4417,
          },
          {
            name: "Done BA CR (Selisih)",
            y: 4.39,
            z: 991,
          },
          {
            name: "EJ Done",
            y: 32.55,
            z: 7342,
            // sliced: true,
            // selected: true,
          },
          {
            name: "OS EJ CR (Tidak Selisih)",
            y: 2.97,
            z: 669,
          },
          {
            name: "Done BA CR (Tidak Selisih)",
            y: 37.91,
            z: 8550,
          },
        ],
      },
    ],
  });

  Highcharts.chart("outstandingEJNoDifference", {
    chart: {
      height: 360,
      type: "column",
      styledMode: true,
    },
    credits: {
      enabled: false,
    },
    title: {
      text: null,
    },
    accessibility: {
      announceNewData: {
        enabled: true,
      },
    },
    xAxis: {
      type: "category",
    },
    yAxis: {
      title: {
        text: "EJ Pending",
      },
    },
    legend: {
      enabled: false,
    },
    plotOptions: {
      series: {
        borderWidth: 0,
        dataLabels: {
          enabled: true,
          format: "{point.y:.1f}%",
        },
      },
    },
    tooltip: {
      headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
      pointFormat:
        '<span style="color:{point.color}">{point.name}</span>: {point.y:.2f}% | {point.z} EJ Pending<br/>',
    },
    series: [
      {
        name: "Traffic Sources",
        colorByPoint: true,
        data: [
          {
            name: "BCA",
            y: 15.68,
            z: 521,
            drilldown: "BCA",
          },
          {
            name: "BNI",
            y: 14.79,
            z: 439,
            drilldown: "BNI",
          },
          {
            name: "Maybank",
            y: 12.45,
            z: 391,
            drilldown: "Maybank",
          },
          {
            name: "BRI",
            y: 10.58,
            z: 231,
            drilldown: "BRI",
          },
        ],
      },
    ],
  });

  Highcharts.chart("outstandingDifference", {
    chart: {
      height: 360,
      type: "column",
      styledMode: true,
    },
    credits: {
      enabled: false,
    },
    title: {
      text: null,
    },
    accessibility: {
      announceNewData: {
        enabled: true,
      },
    },
    xAxis: {
      type: "category",
    },
    yAxis: {
      title: {
        text: "EJ Pending",
      },
    },
    legend: {
      enabled: false,
    },
    plotOptions: {
      series: {
        borderWidth: 0,
        dataLabels: {
          enabled: true,
          format: "{point.y:.1f}%",
        },
      },
    },
    tooltip: {
      headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
      pointFormat:
        '<span style="color:{point.color}">{point.name}</span>: {point.y:.2f}% | {point.z} EJ Pending<br/>',
    },
    series: [
      {
        name: "Traffic Sources",
        colorByPoint: true,
        data: [
          {
            name: "BCA",
            y: 15.68,
            z: 521,
            drilldown: "BCA",
          },
          {
            name: "BNI",
            y: 14.79,
            z: 439,
            drilldown: "BNI",
          },
          {
            name: "Maybank",
            y: 12.45,
            z: 391,
            drilldown: "Maybank",
          },
          {
            name: "BRI",
            y: 10.58,
            z: 231,
            drilldown: "BRI",
          },
        ],
      },
    ],
  });

  Highcharts.chart("transactionSummary", {
    // chart: {
    //   plotBackgroundColor: null,
    //   plotBorderWidth: null,
    //   plotShadow: false,
    //   type: "pie",
    //   styledMode: true,
    // },
    credits: {
      enabled: false,
    },
    title: {
      text: null,
    },
    tooltip: {
      pointFormat: "{series.name}: <b>{point.percentage:.1f}%</b>",
    },
    accessibility: {
      point: {
        valueSuffix: "%",
      },
    },
    plotOptions: {
      pie: {
        allowPointSelect: true,
        cursor: "pointer",
      },
    },
    series: [
      {
        type: "pie",
        name: "Transaction",
        colorByPoint: true,
        dataLabels: {
          // enabled: true,
          format: "<b>{point.name}</b>: {point.y}%",
          style: {
            fontSize: 13,
          },
        },
        data: [
          {
            name: "Realization",
            y: 91.63,
          },
          {
            name: "Cancel",
            y: 6.08,
          },
          {
            name: "Deleted",
            y: 2.28,
          },
        ],
      },
    ],
  });
});
