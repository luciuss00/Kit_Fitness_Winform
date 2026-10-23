namespace Kit_Fitness.Forms;

public sealed partial class frmExpiringFoodNotification : Form
{
    private readonly List<FridgeItemDisplay> _items;

    public frmExpiringFoodNotification(List<FridgeItemDisplay> items)
    {
        InitializeComponent();
        _items = items ?? new List<FridgeItemDisplay>();
        RenderItems();
    }

    private void RenderItems()
    {
        pnlContent.SuspendLayout();
        pnlContent.Controls.Clear();

        if (_items.Count == 0)
        {
            lblSubtitle.Text = "Tất cả thực phẩm trong tủ lạnh của bạn đều đang còn hạn sử dụng";
            btnGoToFridge.Text = "🧊  Xem Tủ Lạnh";

            var pnlEmpty = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 160,
                Padding = new Padding(20)
            };

            var lblEmptyIcon = new Label
            {
                Text = "🌿",
                Font = new Font("Segoe UI", 28F),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            var lblEmptyTitle = new Label
            {
                Text = "Tủ lạnh của bạn đang rất an toàn!",
                Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(34, 76, 56),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };

            var lblEmptyDesc = new Label
            {
                Text = "Không có thực phẩm nào hết hạn hoặc cận hạn trong 3 ngày tới.",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(120, 120, 115),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 30
            };

            pnlEmpty.Controls.Add(lblEmptyDesc);
            pnlEmpty.Controls.Add(lblEmptyTitle);
            pnlEmpty.Controls.Add(lblEmptyIcon);
            pnlContent.Controls.Add(pnlEmpty);
            pnlContent.ResumeLayout(true);
            return;
        }

        lblSubtitle.Text = $"Có {_items.Count} món thực phẩm cần ưu tiên sử dụng trong 3 ngày tới:";

        int top = 16;
        int cardWidth = pnlContent.ClientSize.Width - 40;
        if (cardWidth < 300) cardWidth = 520;

        foreach (var item in _items)
        {
            var card = CreateItemCard(item, cardWidth);
            card.Location = new Point(20, top);
            pnlContent.Controls.Add(card);
            top += card.Height + 10;
        }

        pnlContent.ResumeLayout(true);
    }

    private Panel CreateItemCard(FridgeItemDisplay item, int width)
    {
        var card = new Panel
        {
            Width = width,
            Height = 78,
            BackColor = Color.White,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        // Icon ngăn lưu trữ
        string storageIcon = item.StorageType == "FREEZER" ? "❄️" : "🧊";
        string storageName = item.StorageType == "FREEZER" ? "Ngăn đông" : "Ngăn mát";

        var lblIcon = new Label
        {
            Text = storageIcon,
            Font = new Font("Segoe UI", 16F),
            Location = new Point(14, 16),
            Size = new Size(36, 40),
            TextAlign = ContentAlignment.MiddleCenter
        };

        var lblName = new Label
        {
            Text = item.FoodName,
            Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
            ForeColor = Color.FromArgb(40, 40, 40),
            Location = new Point(56, 12),
            Size = new Size(width - 200, 24),
            AutoEllipsis = true
        };

        var lblInfo = new Label
        {
            Text = $"Số lượng: {item.Quantity:0.##} {item.Unit}  •  {storageName}  •  HSD: {(item.ExpiryDate.HasValue ? item.ExpiryDate.Value.ToString("dd/MM/yyyy") : "--")}",
            Font = new Font("Segoe UI", 9F),
            ForeColor = Color.FromArgb(120, 120, 115),
            Location = new Point(56, 42),
            Size = new Size(width - 70, 24),
            AutoEllipsis = true
        };

        // Badge trạng thái
        var (badgeText, badgeBg, badgeFg) = GetStatusBadge(item.DaysRemaining);
        var lblBadge = new Label
        {
            Text = badgeText,
            Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold),
            BackColor = badgeBg,
            ForeColor = badgeFg,
            TextAlign = ContentAlignment.MiddleCenter,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(width - 140, 16),
            Size = new Size(126, 26)
        };

        card.Controls.Add(lblBadge);
        card.Controls.Add(lblInfo);
        card.Controls.Add(lblName);
        card.Controls.Add(lblIcon);

        // Vẽ viền nhẹ cho card
        card.Paint += (s, e) =>
        {
            using var pen = new Pen(Color.FromArgb(232, 228, 220));
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        };

        return card;
    }

    private static (string Text, Color Bg, Color Fg) GetStatusBadge(int days)
    {
        if (days < 0)
        {
            return ($"Đã quá hạn {-days} ngày", Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28));
        }
        if (days == 0)
        {
            return ("Hôm nay hết hạn!", Color.FromArgb(254, 240, 138), Color.FromArgb(133, 77, 14));
        }
        if (days == 1)
        {
            return ("Còn 1 ngày", Color.FromArgb(255, 237, 213), Color.FromArgb(194, 65, 12));
        }
        return ($"Còn {days} ngày", Color.FromArgb(254, 249, 195), Color.FromArgb(161, 98, 7));
    }

    private void BtnGoToFridge_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }

    private void BtnClose_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void frmExpiringFoodNotification_Load(object sender, EventArgs e)
    {

    }
}
