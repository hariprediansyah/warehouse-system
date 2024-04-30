$(function () {
  "use strict";

  var options = {
    series: [60.83, 39.17],
    chart: {
      foreColor: "#9ba7b2",
      height: 330,
      type: "pie",
    },
    colors: ["#3CD856", "#FA5A7D"],
    labels: ["Index Up", "Index Bottom"],
    legend: {
      position: "bottom",
    },
    tooltip: {
      enabled: true,
      y: {
        formatter: function (val) {
          return val + "%";
        },
      },
    },
    dataLabels: {
      enabled: true,
      style: {
        fontSize: "14px",
        fontFamily: "Helvetica, Arial, sans-serif",
        fontWeight: "bold",
        colors: ["000"],
      },
      formatter: function (val, opts) {
        return (
          opts.w.globals.labels[opts.seriesIndex] + ": " + val.toFixed(2) + "%"
        );
      },
    },
    responsive: [
      {
        breakpoint: 480,
        options: {
          chart: {
            height: 360,
          },
          legend: {
            position: "bottom",
          },
        },
      },
    ],
  };
  var chart = new ApexCharts(document.querySelector("#indexOvertime"), options);
  chart.render();

  var options = {
    chart: {
      height: 300,
      type: "radialBar",
      toolbar: {
        show: false,
      },
    },
    plotOptions: {
      radialBar: {
        //startAngle: -135,
        //endAngle: 225,
        hollow: {
          margin: 0,
          size: "78%",
          //background: '#fff',
          image: undefined,
          imageOffsetX: 0,
          imageOffsetY: 0,
          position: "front",
          dropShadow: {
            enabled: false,
            top: 3,
            left: 0,
            blur: 4,
            color: "rgba(7, 39, 215, 0.25)",
            opacity: 0.65,
          },
        },
        track: {
          background: "#f0e6ff",
          //strokeWidth: '67%',
          margin: 0, // margin is in pixels
          dropShadow: {
            enabled: false,
            top: -3,
            left: 0,
            blur: 4,
            color: "rgba(7, 39, 215, 0.85)",
            opacity: 0.65,
          },
        },
        dataLabels: {
          showOn: "always",
          name: {
            offsetY: -25,
            show: true,
            color: "#6c757d",
            fontSize: "16px",
          },
          value: {
            formatter: function (val) {
              return val + "%";
            },
            color: "#000",
            fontSize: "45px",
            show: true,
            offsetY: 10,
          },
        },
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        type: "horizontal",
        shadeIntensity: 0.5,
        gradientToColors: ["#0095FF"],
        inverseColors: false,
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100],
      },
    },
    colors: ["#0095FF"],
    series: [25.14],
    stroke: {
      lineCap: "round",
      //dashArray: 4
    },
    labels: ["Average"],
  };
  var chart = new ApexCharts(
    document.querySelector("#chartRatioOvertime"),
    options
  );
  chart.render();

  var options = {
    chart: {
      height: 300,
      type: "radialBar",
      toolbar: {
        show: false,
      },
    },
    plotOptions: {
      radialBar: {
        //startAngle: -135,
        //endAngle: 225,
        hollow: {
          margin: 0,
          size: "78%",
          //background: '#fff',
          image: undefined,
          imageOffsetX: 0,
          imageOffsetY: 0,
          position: "front",
          dropShadow: {
            enabled: false,
            top: 3,
            left: 0,
            blur: 4,
            color: "rgba(7, 39, 215, 0.25)",
            opacity: 0.65,
          },
        },
        track: {
          background: "#f0e6ff",
          //strokeWidth: '67%',
          margin: 0, // margin is in pixels
          dropShadow: {
            enabled: false,
            top: -3,
            left: 0,
            blur: 4,
            color: "rgba(7, 39, 215, 0.85)",
            opacity: 0.65,
          },
        },
        dataLabels: {
          showOn: "always",
          name: {
            offsetY: -25,
            show: true,
            color: "#6c757d",
            fontSize: "16px",
          },
          value: {
            formatter: function (val) {
              return val + "%";
            },
            color: "#000",
            fontSize: "32px",
            show: true,
            offsetY: 10,
          },
        },
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        type: "horizontal",
        shadeIntensity: 0.5,
        gradientToColors: ["#0095FF"],
        inverseColors: false,
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100],
      },
    },
    colors: ["#0095FF"],
    series: [66.34],
    stroke: {
      lineCap: "round",
      //dashArray: 4
    },
    labels: ["Reached"],
  };
  var chart = new ApexCharts(
    document.querySelector("#SLAAchievement"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Achieved",
        data: [786, 1000, 678, 491, 785, 873, 700],
      },
      {
        name: "Not Achieved",
        data: [462, 869, 987, 614, 598, 672, 500],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      type: "bar",
      height: 360,
    },
    plotOptions: {
      bar: {
        dataLabels: {
          position: "top",
        },
        horizontal: false,
        columnWidth: "55%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: true,
      offsetY: -20,
      style: {
        colors: ["#000"],
      },
    },
    stroke: {
      show: true,
      width: 2,
      colors: ["transparent"],
    },
    // title: {
    //   text: "C",
    //   align: "left",
    //   style: {
    //     fontSize: "14px",
    //   },
    // },
    colors: ["#00E096", "#FFCF00"],
    xaxis: {
      categories: ["ATMI", "BCA", "BNI", "BRI", "Maybank", "CIMB", "PMT"],
      labels: {
        show: true,
        rotate: -45,
        rotateAlways: false,
        hideOverlappingLabels: true,
        showDuplicates: false,
        trim: false,
        minHeight: undefined,
        maxHeight: 120,
        style: {
          colors: [
            "000000",
            "000000",
            "000000",
            "000000",
            "000000",
            "000000",
            "000000",
          ],
          fontSize: "13px",
          fontFamily: "Helvetica, Arial, sans-serif",
          fontWeight: 500,
          cssClass: "apexcharts-xaxis-label",
        },
        offsetX: 0,
        offsetY: 0,
        format: undefined,
        formatter: undefined,
      },
    },

    fill: {
      opacity: 1,
    },
    tooltip: {
      y: {
        formatter: function (val) {
          return val + " Mesin";
        },
      },
    },
    legend: {
      show: true,
      showForSingleSeries: false,
      showForNullSeries: true,
      showForZeroSeries: true,
      position: "bottom",
      horizontalAlign: "center",
      floating: false,
      fontSize: "14px",
      fontFamily: "Helvetica, Arial",
      fontWeight: 400,
      formatter: undefined,
      inverseOrder: false,
      width: undefined,
      height: undefined,
      tooltipHoverFormatter: undefined,
      customLegendItems: [],
      offsetX: 0,
      offsetY: 7,
      labels: {
        colors: undefined,
        useSeriesColors: false,
      },
      markers: {
        width: 12,
        height: 12,
        strokeWidth: 0,
        strokeColor: "#fff",
        fillColors: undefined,
        radius: 12,
        customHTML: undefined,
        onClick: undefined,
        offsetX: 0,
        offsetY: 0,
      },
      itemMargin: {
        horizontal: 5,
        vertical: 0,
      },
      onItemClick: {
        toggleDataSeries: true,
      },
      onItemHover: {
        highlightDataSeries: true,
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#acvhievmentOfSLABank"),
    options
  );
  chart.render();

  // CPC START HERE !!!

  var options = {
    series: [
      {
        name: "Ratio",
        data: [84, 89, 79, 87, 80, 98, 78, 91, 88, 90, 93, 78],
      },
    ],
    chart: {
      foreColor: "#9a9797",
      type: "area",
      height: 380,
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 4,
      curve: "smooth",
    },
    xaxis: {
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
      formatter: function (val, opts) {
        return val + "%";
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#0095ff"],
        shadeIntensity: 1,
        type: "vertical",
        opacityFrom: 0.8,
        opacityTo: 0.3,
        //stops: [0, 100, 100, 100]
      },
    },
    colors: ["#0095ff"],
    yaxis: {
      labels: {
        formatter: function (value) {
          return +value + "%";
        },
      },
    },
    markers: {
      size: 4,
      colors: ["#0095ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    grid: {
      show: true,
      borderColor: "#ededed",
      strokeDashArray: 4,
    },
  };
  var chart = new ApexCharts(document.querySelector("#chartMonth"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "2024",
        data: [31, 40, 68, 31, 92, 55, 100, 78, 87, 56, 45, 77],
      },
      {
        name: "2023",
        data: [11, 82, 45, 80, 34, 52, 41, 87, 76, 43, 90, 88],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 380,
      type: "area",
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: true,
      },
    },
    colors: ["#0095ff", "#fd3550"],
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
      formatter: function (val, opts) {
        return val + "%";
      },
    },
    stroke: {
      curve: "smooth",
    },
    xaxis: {
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
    },
    yaxis: {
      labels: {
        formatter: function (value) {
          return +value + "%";
        },
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#chartCompareYear"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Sessions",
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "line",
      height: 60,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#8833ff",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#8833ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.5,
      curve: "smooth",
    },
    colors: ["#8833ff"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#bigDeposit"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Total Users",
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "bar",
      height: 60,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#f41127",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#f41127"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "40%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.5,
      curve: "smooth",
    },
    colors: ["#f41127"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#smallDeposit"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Page Views",
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "area",
      height: 60,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#ffc107",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#ffc107"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.5,
      curve: "smooth",
    },
    colors: ["#ffc107"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#brickPrepare"), options);
  chart.render();

  // chart 4
  var options = {
    series: [
      {
        name: "Bounce Rate",
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "bar",
      height: 60,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#0dcaf0",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#0dcaf0"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "40%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#0dcaf0"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#brickReturn"), options);
  chart.render();

  // chart 5
  var options = {
    series: [
      {
        name: "Avg. Session Duration",
        data: [414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "line",
      height: 60,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#29cc39",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#29cc39"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.5,
      curve: "smooth",
    },
    colors: ["#29cc39"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#brickCDR"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Total Orders",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#ffb207",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#ffb207"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#ffb207"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#totalCashier"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Total Income",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#0095ff",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#0095ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#0095ff"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#totalEmployeeCPC"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Total Users",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#f41127",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#f41127"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#f41127"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#pendingSortir"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Comments",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#17a00e",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#17a00e"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#17a00e"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#selisihMinus"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Comments",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 257],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#8833ff",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#8833ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#8833ff"],
    xaxis: {
      categories: [
        "Week 1",
        "Week 2",
        "Week 3",
        "Week 4",
        "Week 5",
        "Week 6",
        "Week 7",
        "Week 8",
        "Week 9",
        "Week 10",
        "Week 11",
        "Week 12",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#selisihPlus"), options);
  chart.render();

  // END CPC HERE !!!

  // CDC START HERE !!!

  var options = {
    series: [
      {
        name: "Cancel",
        data: [374, 842, 542, 422, 321, 457, 563, 643],
      },
    ],
    chart: {
      foreColor: "#9a9797",
      type: "area",
      height: 380,
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 4,
      curve: "smooth",
    },
    xaxis: {
      type: "day",
      categories: [
        "1/11/2023",
        "2/11/2023",
        "3/11/2023",
        "4/11/2023",
        "5/11/2023",
        "6/11/2023",
        "7/11/2023",
        "8/11/2023",
      ],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#0095ff"],
        shadeIntensity: 1,
        type: "vertical",
        opacityFrom: 0.8,
        opacityTo: 0.3,
        //stops: [0, 100, 100, 100]
      },
    },
    colors: ["#0095ff"],
    yaxis: {
      labels: {
        formatter: function (value) {
          return value;
        },
      },
    },
    markers: {
      size: 4,
      colors: ["#0095ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    grid: {
      show: true,
      borderColor: "#ededed",
      strokeDashArray: 4,
    },
  };
  var chart = new ApexCharts(document.querySelector("#cancelByBank"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Selisih",
        data: [1559, 1316, 1456, 1339, 1467, 417, 324, 312],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 360,
      type: "line",
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: true,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 5,
      curve: "smooth",
    },
    xaxis: {
      type: "day",
      categories: [
        "1/02/2024",
        "2/02/2024",
        "3/02/2024",
        "4/02/2024",
        "5/02/2024",
        "6/02/2024",
        "7/02/2024",
        "8/02/2024",
      ],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#8833ff"],
        shadeIntensity: 1,
        type: "horizontal",
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100, 100, 100],
      },
    },
    markers: {
      size: 4,
      colors: ["#8833ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    colors: ["#8833ff"],
    yaxis: {
      title: {
        text: "Selisih",
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#cancelBasedFactor"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Selisih",
        data: [1242, 1452, 1114, 1289, 1354, 982, 1652, 1422],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 360,
      type: "line",
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: true,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 5,
      curve: "smooth",
    },
    xaxis: {
      type: "day",
      categories: [
        "1/02/2024",
        "2/02/2024",
        "3/02/2024",
        "4/02/2024",
        "5/02/2024",
        "6/02/2024",
        "7/02/2024",
        "8/02/2024",
      ],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#07E098"],
        shadeIntensity: 1,
        type: "horizontal",
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100, 100, 100],
      },
    },
    markers: {
      size: 4,
      colors: ["#07E098"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    colors: ["#07E098"],
    yaxis: {
      title: {
        text: "Selisih",
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#cancelDataReal"),
    options
  );
  chart.render();

  // END CDC HERE !!!

  var options = {
    series: [
      {
        name: "Sectors",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 867],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#FA5A7D",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#FA5A7D"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#FA5A7D"],
    xaxis: {
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#sectorsFLM1"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "FLM - Sectors",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 964],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#FF947A",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#FF947A"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#FF947A"],
    xaxis: {
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#sectorsFLM2"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "FLM - Sectors",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 642],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#3CD856",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#3CD856"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#3CD856"],
    xaxis: {
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#atmFLM"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "FLM - Sectors",
        data: [240, 160, 671, 414, 555, 257, 901, 613, 727, 414, 555, 876],
      },
    ],
    chart: {
      type: "area",
      height: 65,
      toolbar: {
        show: false,
      },
      zoom: {
        enabled: false,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.12,
        color: "#BF83FF",
      },
      sparkline: {
        enabled: true,
      },
    },
    markers: {
      size: 0,
      colors: ["#BF83FF"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    plotOptions: {
      bar: {
        horizontal: false,
        columnWidth: "45%",
        endingShape: "rounded",
      },
    },
    dataLabels: {
      enabled: false,
    },
    stroke: {
      show: true,
      width: 2.4,
      curve: "smooth",
    },
    colors: ["#BF83FF"],
    xaxis: {
      categories: [
        "Jan",
        "Feb",
        "Mar",
        "Apr",
        "May",
        "Jun",
        "Jul",
        "Aug",
        "Sep",
        "Oct",
        "Nov",
        "Dec",
      ],
    },
    fill: {
      opacity: 1,
    },
    tooltip: {
      theme: "dark",
      fixed: {
        enabled: false,
      },
      x: {
        show: false,
      },
      y: {
        title: {
          formatter: function (seriesName) {
            return "";
          },
        },
      },
      marker: {
        show: false,
      },
    },
  };
  var chart = new ApexCharts(document.querySelector("#employeesFLM"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Ratio Data",
        type: "column",
        data: [
          49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1,
          95.6, 54.4,
        ],
      },
      {
        name: "Average",
        type: "line",
        data: [
          7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6,
        ],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 350,
      type: "line",
      zoom: {
        enabled: true,
      },
      toolbar: {
        show: true,
      },
    },
    stroke: {
      width: [0, 4],
    },
    plotOptions: {
      bar: {
        //horizontal: true,
        columnWidth: "35%",
        endingShape: "rounded",
      },
    },
    colors: ["#0095FF", "#000000"],
    // title: {
    //   text: null,
    // },
    dataLabels: {
      enabled: true,
      enabledOnSeries: [1],
    },
    labels: [
      "Cideng",
      "Karawang",
      "Meruya",
      "Pontianak",
      "Rawamangun",
      "Semarang",
      "Serang",
      "Tegal",
      "Bandung",
      "Banjarmasin",
      "Jambi",
      "Purwokerto",
    ],
    xaxis: {
      type: "text",
    },
    yaxis: [
      {
        title: {
          text: "Ratio Data",
        },
      },
      {
        opposite: true,
        title: {
          text: "Average",
        },
      },
    ],
  };
  var chart = new ApexCharts(document.querySelector("#FLMSector"), options);
  chart.render();

  var options = {
    series: [
      {
        name: "Ratio Data",
        type: "column",
        data: [
          49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1,
          95.6, 54.4,
        ],
      },
      {
        name: "Average",
        type: "line",
        data: [
          7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6,
        ],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 350,
      type: "line",
      zoom: {
        enabled: true,
      },
      toolbar: {
        show: true,
      },
    },
    stroke: {
      width: [0, 4],
    },
    plotOptions: {
      bar: {
        //horizontal: true,
        columnWidth: "35%",
        endingShape: "rounded",
      },
    },
    colors: ["#BF83FF", "#000"],
    // title: {
    //   text: null,
    // },
    dataLabels: {
      enabled: true,
      enabledOnSeries: [1],
    },
    labels: [
      "Cideng",
      "Karawang",
      "Meruya",
      "Pontianak",
      "Rawamangun",
      "Semarang",
      "Serang",
      "Tegal",
      "Bandung",
      "Banjarmasin",
      "Jambi",
      "Purwokerto",
    ],
    xaxis: {
      type: "text",
    },
    yaxis: [
      {
        title: {
          text: "Ratio Data",
        },
      },
      {
        opposite: true,
        title: {
          text: "Average",
        },
      },
    ],
  };
  var chart = new ApexCharts(
    document.querySelector("#FLMSectorNumberofATMEmployees"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Selisih",
        data: [-11, -14, -1, -16, 0, 0, 0, 0],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 360,
      type: "line",
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: true,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 5,
      curve: "smooth",
    },
    xaxis: {
      type: "day",
      categories: [
        "1/11/2023",
        "2/11/2023",
        "3/11/2023",
        "4/11/2023",
        "5/11/2023",
        "6/11/2023",
        "7/11/2023",
        "8/11/2023",
      ],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#8833ff"],
        shadeIntensity: 1,
        type: "horizontal",
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100, 100, 100],
      },
    },
    markers: {
      size: 4,
      colors: ["#8833ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    colors: ["#8833ff"],
    yaxis: {
      title: {
        text: "Selisih",
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#selisihKebutuhanRun"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Duration (Hours)",
        data: [1239, 1684, 1822],
      },
    ],
    chart: {
      foreColor: "#9a9797",
      type: "area",
      height: 380,
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: false,
      },
      dropShadow: {
        enabled: false,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 4,
      curve: "smooth",
    },
    xaxis: {
      categories: ["Nov", "Dec", "Jan"],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#0095ff"],
        shadeIntensity: 1,
        type: "vertical",
        opacityFrom: 0.8,
        opacityTo: 0.3,
        //stops: [0, 100, 100, 100]
      },
    },
    colors: ["#0095ff"],
    yaxis: {
      labels: {
        formatter: function (value) {
          return value;
        },
      },
    },
    markers: {
      size: 4,
      colors: ["#0095ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    grid: {
      show: true,
      borderColor: "#ededed",
      strokeDashArray: 4,
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#durasiLemburCabang"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Selisih",
        data: [282, 251, 48, 105],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 360,
      type: "line",
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: true,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 5,
      curve: "smooth",
    },
    xaxis: {
      type: "month",
      categories: ["Nov", "Dec", "Jan", "Feb"],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#0095ff"],
        shadeIntensity: 1,
        type: "horizontal",
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100, 100, 100],
      },
    },
    markers: {
      size: 4,
      colors: ["#0095ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    colors: ["#0095ff"],
    yaxis: {
      title: {
        text: "Selisih",
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#summaryEJPendingNoDifference"),
    options
  );
  chart.render();

  var options = {
    series: [
      {
        name: "Selisih",
        data: [209, 558, 33, 71],
      },
    ],
    chart: {
      foreColor: "#9ba7b2",
      height: 360,
      type: "line",
      zoom: {
        enabled: false,
      },
      toolbar: {
        show: true,
      },
      dropShadow: {
        enabled: true,
        top: 3,
        left: 14,
        blur: 4,
        opacity: 0.1,
      },
    },
    stroke: {
      width: 5,
      curve: "smooth",
    },
    xaxis: {
      type: "month",
      categories: ["Nov", "Dec", "Jan", "Feb"],
    },
    dataLabels: {
      enabled: true,
      style: {
        colors: ["#000"],
      },
    },
    fill: {
      type: "gradient",
      gradient: {
        shade: "light",
        gradientToColors: ["#8833ff"],
        shadeIntensity: 1,
        type: "horizontal",
        opacityFrom: 1,
        opacityTo: 1,
        stops: [0, 100, 100, 100],
      },
    },
    markers: {
      size: 4,
      colors: ["#8833ff"],
      strokeColors: "#fff",
      strokeWidth: 2,
      hover: {
        size: 7,
      },
    },
    colors: ["#8833ff"],
    yaxis: {
      title: {
        text: "Selisih",
      },
    },
  };
  var chart = new ApexCharts(
    document.querySelector("#summaryEJPendingDifference"),
    options
  );
  chart.render();
});
