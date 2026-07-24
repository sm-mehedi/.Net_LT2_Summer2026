using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloodBankApp.EF.Tables;

public partial class Donor
{
    public int DonorId { get; set; }

    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "Blood group is required")]
    [RegularExpression("^(A|B|AB|O)[+-]$", ErrorMessage = "Blood group must be one of A+, A-, B+, B-, AB+, AB-, O+, O-")]
    public string BloodGroup { get; set; } = null!;

    [Required(ErrorMessage = "Contact number is required")]
    [StringLength(20, ErrorMessage = "Contact number cannot exceed 20 characters")]
    [RegularExpression(@"^[0-9+\-\s]+$", ErrorMessage = "Contact number may only contain digits, spaces, + and -")]
    public string ContactNo { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
    public string City { get; set; } = null!;

    public DateOnly? LastDonationDate { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
