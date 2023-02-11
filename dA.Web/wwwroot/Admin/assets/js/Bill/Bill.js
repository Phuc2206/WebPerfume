function reformatDate(dateStr) {
	dArr = dateStr.split("-");  // ex input "2010-01-18"
	return dArr[2] + "/" + dArr[1] + "/" + dArr[0].substring(2); //ex out: "18/01/10"
}

/* ajax lay du lieu len*/
function loaddata(_page) {
	$.ajax({
		type: 'get',
		url: '/Admin/Bill/GetList?page=' + _page,
		success: function (res) {
			$('.bill').html('');
			render(res.data);
			var currentPage = res.currentPage;
			var pageSize = res.perPage;
			var totalRow = res.pageCount;
			var arrPager = getPager(currentPage, pageSize, totalRow);
			arrPager = arrPager.map(function (item) {
				var eleClass = "";
				if (item.isCurrentPage) {
					eleClass = "active";
				}
				return (
					'<li><a class="border-radius-0 btn btn-outline-secondary ' +
					eleClass +
					'" data-page="' +
					item.page +
					'" href="#">' +
					item.text +
					"</a></li>"
				);
			});
			var pagination = $(".pagination");
			pagination.html(arrPager.join(""));
		}
	}).then(function () {
		$("a[data-page]").click(function (ev) {
			ev.preventDefault();
			page = $(ev.currentTarget).attr("data-page");
			loaddata(page);
		});
	});
};

function render(data) {
	var tbody = $(".bill");
	return data.forEach(function (res, index) {
		var tr = $('<tr>').appendTo(tbody);
		var td = `		<td>${res.id}</td>
						<td >${res.fullname}</td>
						<td >${reformatDate(res.createDate.slice(0, 10))}</td>
						<td>${formatVND(res.total)}</td>
						<td data-id="${res.id}">
							<div class="btn-group btn-group-sm" role="group">
								<button data-bs-toggle="modal"
								  data-bs-target=".bs-example-modal-xl" type="button" class="btn btn-outline-secondary waves-effect waves-light js-detail" data-id="${res.id}" >
									<i class="fas fa-eye"></i>
								</button>
								<a hef="#" class="btn btn-outline-secondary js-delete" data-id="${res.id}">
									<i class="fas fa-trash-alt"></i>
								</a>
							</div>
						</td>`
		$(td).appendTo(tr);
	});
};
window.addEventListener('load', () => {
	loaddata();
});


// btn huy modal
$("#btnClose").on("click", function () {
	$("#Id").val(null);
	$('#Category_modal').modal('hide')
});
// btn lưu modal
$("#btnSaveCategory").on("click", function (ev) {
	ev.preventDefault();
	var form = $("#CategoryForm");
	var data = new FormData(form[0]);
	$.ajax({
		url: "/Admin/Category/AddOrUpdate",
		data: data,
		dataType: 'json',
		type: "POST",
		processData: false,
		contentType: false,
		success: function (res) {
			if (res == true) {
				$('#Category_modal').modal('hide');
				$("#CategoryForm")[0].reset();
				Swal.fire({
					position: 'center',
					icon: 'success',
					title: 'Thao tác thành công',
					showConfirmButton: false,
					timer: 1500
				})
				loaddata();
			}
			else {
				Swal.fire({
					position: 'center',
					icon: 'error',
					title: 'Thao tác thất bại',
					showConfirmButton: false,
					timer: 1500
				})
			}
		}
	});
})







// js delete 
$(document).on("click", ".js-delete", function (ev) {
	ev.preventDefault();
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	$.ajax({
		type: "DELETE",
		data: { id: id },
		url: "/Admin/Bill/Remove",
		dataType: "json",
		success: function (res) {
			if (res == true) {
				Swal.fire({
					position: 'center',
					icon: 'success',
					title: 'Thao tác thành công',
					showConfirmButton: false,
					timer: 1500
				})
				loaddata();
			}
			else {
				Swal.fire({
					position: 'center',
					icon: 'error',
					title: 'Thao tác thất bại',
					showConfirmButton: false,
					timer: 1500
				})
			}
		}
	});
})



// format tien 
function formatVND(money) {
	var y = Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' });
	return y.format(money)
};

// phan trang js 
function getPager(currentPage, pageSize, totalRow) {
	const ON_EACH_SIDE = 1;
	var arrPager = [];
	var totalPage = Math.ceil(totalRow / pageSize);

	currentPage = parseInt(currentPage);
	if (totalPage == 0) {
		return arrPager;
	}
	else {
		// current page
		arrPager.push({
			isCurrentPage: true,
			text: currentPage,
			page: currentPage,
		});
		// after current page
		var i = 1;
		while (currentPage + i <= totalPage) {
			arrPager.push({
				isCurrentPage: false,
				text: currentPage + i,
				page: currentPage + i,
			});
			i++;
			if (i > ON_EACH_SIDE) break;
		}
		if (currentPage + ON_EACH_SIDE < totalPage) {
			arrPager.push({
				isCurrentPage: false,
				text: "&rArr;",
				page: totalPage,
			});
		}

		// before current page
		i = 1;
		var tmp = currentPage;
		while (tmp > 1) {
			arrPager.unshift({
				isCurrentPage: false,
				text: currentPage - i,
				page: currentPage - i,
			});
			i++;
			tmp--;
			if (i > ON_EACH_SIDE) break;
		}
		if (currentPage - ON_EACH_SIDE > 1) {
			arrPager.unshift({
				isCurrentPage: false,
				text: "&lArr;",
				page: 1,
			});
		}
	}
	return arrPager;
}

$(document).on("click", ".js-detail", function (ev) {
	ev.preventDefault();
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	GetDetail(ev);
	function GetDetail(ev) {
		$.ajax({
			type: 'get',
			url: '/Admin/Bill/GetAllDetail',
			data: { id: id },
			success: function (res) {
				console.log(res);
				// thông tin khách hàng
				

				$('.billdetail').html('');
				renderDetail(res);
				$(".namecus").text(res[0].idBillNavigation.fullname);
				$(".addresscus").text(res[0].idBillNavigation.addresss);
				$(".deliveryAddresscus").text(res[0].idBillNavigation.deliveryAddress)
				$(".emailcus").text(res[0].idBillNavigation.email);
				$(".sdtcus").text(res[0].idBillNavigation.phonenumber);
				$(".notecus").text(res[0].idBillNavigation.note);
				$(".createbill").text(reformatDate(res[0].idBillNavigation.createDate.slice(0, 10)));
				$(".totalbill").text(formatVND(res[0].idBillNavigation.total));

			}
		});
	};
	function renderDetail(data) {
		var tbody = $(".billdetail");
		return data.forEach(function (res, index) {
			var tr = $('<tr>').appendTo(tbody);
			var td = `
							<th scope="row">${index}</th>
							<td>
								<h5 class="font-size-15 mb-1">${res.billProduct.name}</h5>
								<ul class="list-inline mb-0">
									<li class="list-inline-item">
										Size : <span class="fw-medium">${res.size}</span>
									</li>
								</ul>
							</td>
							<td> <img style="height:100px ; width:100px;  object-fit:cover;" src="/Images/Product/${res.billProduct.urlPicture}"></td>

							<td>${formatVND(res.billProduct.price)}</td>
							<td>${res.quantity}</td>
							<td scope="col"class="text-end">${formatVND(res.totalProduct)}</td>
					`
			$(td).appendTo(tr);
		});
	};

});