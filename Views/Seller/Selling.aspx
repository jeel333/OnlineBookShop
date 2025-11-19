<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Seller/sellerMaster.Master" AutoEventWireup="true" CodeBehind="Selling.aspx.cs" Inherits="OnlineBookShop.Views.Seller.Selling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function PrintBill() {
            var grid = document.getElementById('<%=BillList.ClientID%>');
            if (!grid) {
                alert("No bill data to print!");
                return;
            }

            // Create a new print window
            var printWindow = window.open('', 'PrintGrid', 'width=900,height=650,scrollbars=1,resizable=1');

            // Write full HTML document for print
            printWindow.document.write(`
                <html>
                    <head>
                        <title>Bill Receipt</title>
                        <style>
                            body {
                                font-family: Arial, sans-serif;
                                margin: 20px;
                            }
                            h2 {
                                color: teal;
                                text-align: center;
                                margin-bottom: 20px;
                            }
                            table {
                                width: 100%;
                                border-collapse: collapse;
                            }
                            th, td {
                                border: 1px solid #ccc;
                                padding: 8px;
                                text-align: left;
                            }
                            th {
                                background-color: #f2f2f2;
                            }
                            .total {
                                margin-top: 20px;
                                text-align: right;
                                font-weight: bold;
                                font-size: 18px;
                                color: crimson;
                            }
                        </style>
                    </head>
                    <body>
                        <h2>Client Bill</h2>
                        ${grid.outerHTML}
                        <div class="total">
                            Total: ${document.getElementById('<%=GrdTotalTb.ClientID%>').innerText}
                        </div>
                    </body>
                </html>
            `);

            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <!-- Left: Book Details -->
            <div class="col-md-5">
                <h3 class="text-center" style="color: teal;">Book Details</h3>

                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label class="form-label text-success">Book Name</label>
                            <input type="text" placeholder="Book Name" autocomplete="off" runat="server" class="form-control" id="BNameTb" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label class="form-label text-success">Book Price</label>
                            <input type="text" placeholder="Price" autocomplete="off" runat="server" id="BPriceTb" class="form-control" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col">
                        <div class="mt-3">
                            <label class="form-label text-success">Quantity</label>
                            <input type="text" placeholder="Quantity" autocomplete="off" runat="server" id="BQtyTb" class="form-control" />
                        </div>
                    </div>
                    <div class="col">
                        <div class="mt-3">
                            <label class="form-label text-success">Billing Date</label>
                            <input type="datetime-local" runat="server" id="DateTb" class="form-control" />
                        </div>
                    </div>
                </div>

                <div class="row mt-3 mb-3">
                    <div class="col d-grid">
                        <asp:Button 
                            Text="Add To Bill" 
                            runat="server" 
                            ID="addToBillBtn" 
                            CssClass="btn btn-warning btn-block" 
                            OnClick="AddToBillBtn_Click" />
                    </div>
                </div>

                <div class="row mt-5">
                    <h4 class="text-center" style="color: teal;">Book List</h4>
                    <div class="col">
                        <asp:GridView 
                            ID="BooksList" 
                            runat="server" 
                            CssClass="table table-bordered"
                            CellPadding="4" 
                            ForeColor="#333333" 
                            GridLines="None"
                            AutoGenerateSelectButton="True"
                            OnSelectedIndexChanged="BooksList_SelectedIndexChanged">
                            <HeaderStyle BackColor="Teal" ForeColor="White" />
                            <RowStyle BackColor="#E3EAEB" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

            <!-- Right: Client Bill -->
            <div class="col-md-7">
                <h4 class="text-center" style="color: crimson;">Client's Bill</h4>
                <div class="col">
                    <asp:GridView 
                        ID="BillList" 
                        runat="server" 
                        CssClass="table table-bordered"
                        CellPadding="4" 
                        ForeColor="#333333" 
                        GridLines="None">
                        <HeaderStyle BackColor="SlateBlue" ForeColor="White" />
                        <RowStyle BackColor="#E3EAEB" />
                    </asp:GridView>

                    <div class="d-grid text-center mt-3">
                        <asp:Label runat="server" ID="GrdTotalTb" CssClass="text-danger h5"></asp:Label><br />
                        <asp:Button 
                            Text="Print" 
                            runat="server" 
                            ID="PrintBtn" 
                            CssClass="btn btn-warning btn-block" 
                            OnClientClick="PrintBill(); return false;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
