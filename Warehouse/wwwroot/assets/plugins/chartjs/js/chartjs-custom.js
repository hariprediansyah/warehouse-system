$(function () {
  "use strict";

  const labels = ["BCA", "BNI", "BRI", "CIMB", "Maybank"];
  const images = [
    "assets/images/gallery/bca-logo.png",
    "assets/images/gallery/bni-logo.png",
    "assets/images/gallery/bri-logo.png",
    "assets/images/gallery/cimb-logo.png",
    "assets/images/gallery/maybank-logo.png",
  ].map((png) => {
    const image = new Image();
    image.src = png;
    return image;
  });
  const values = [48, 56, 33, 44];
  var ctx = document.getElementById("chartJS").getContext("2d");
  var myChart = new Chart(ctx, {
    type: "bar",
    plugins: [
      {
        afterDraw: (chart) => {
          var ctx = chart.chart.ctx;
          var xAxis = chart.scales["x-axis-0"];
          var yAxis = chart.scales["y-axis-0"];
          xAxis.ticks.forEach((value, index) => {
            var x = xAxis.getPixelForTick(index);
            // Adjust the width here (default 24px)
            var width = 48;
            ctx.drawImage(
              images[index],
              x - width / 2,
              yAxis.bottom + 10,
              width,
              images[index].height * (width / images[index].width)
            );
          });
        },
      },
    ],
    data: {
      labels: labels,
      datasets: [
        {
          label: "Achieved",
          data: [786, 1000, 678, 491, 785],
          // barPercentage: 0.5,
          backgroundColor: "#00E096",
        },
        {
          label: "Not Achieved",
          data: [462, 869, 987, 614, 598],
          // barPercentage: 0.5,
          backgroundColor: "#FFCF00",
        },
      ],
    },
    options: {
      maintainAspectRatio: false,
      legend: {
        display: true,
        labels: {
          fontColor: "#585757",
          boxWidth: 40,
        },
      },
      tooltips: {
        enabled: true,
      },
      scales: {
        xAxes: [
          {
            ticks: {
              beginAtZero: true,
              fontColor: "#fff", // hide label xaxis
            },
            gridLines: {
              display: true,
              color: "rgba(0, 0, 0, 0.07)",
            },
          },
        ],
        yAxes: [
          {
            ticks: {
              beginAtZero: true,
              fontColor: "#585757",
            },
            gridLines: {
              display: true,
              color: "rgba(0, 0, 0, 0.07)",
            },
          },
        ],
      },
    },
  });
});
