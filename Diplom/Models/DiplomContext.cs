using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Diplom.Models;

public partial class DiplomContext : DbContext
{
    public DiplomContext()
    {
    }

    public DiplomContext(DbContextOptions<DiplomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Taskforrequest> Taskforrequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=toor;database=diplom", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract).HasName("PRIMARY");

            entity.ToTable("contract");

            entity.HasIndex(e => e.RequestId, "contract_request_requestID_fk");

            entity.HasIndex(e => e.PartnerId, "contract_user_userID_fk");

            entity.HasIndex(e => e.OrganisationId, "contract_user_userID_fk_2");

            entity.Property(e => e.IdContract).HasColumnName("ID_Contract");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(50)
                .HasColumnName("Contract_status");
            entity.Property(e => e.DateContractStart).HasColumnName("Date_contract_start");
            entity.Property(e => e.DateContractUpdate).HasColumnName("date_contract_update");
            entity.Property(e => e.DateRequestStart).HasColumnName("Date_request_start");
            entity.Property(e => e.DateRequestUpdate).HasColumnName("date_request_update");
            entity.Property(e => e.IkzCode).HasColumnName("IKZ_code");
            entity.Property(e => e.OrganisationId).HasColumnName("organisationID");
            entity.Property(e => e.PartnerId).HasColumnName("partnerID");
            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.StuffName)
                .HasMaxLength(255)
                .HasColumnName("Stuff_Name");
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Organisation).WithMany(p => p.ContractOrganisations)
                .HasForeignKey(d => d.OrganisationId)
                .HasConstraintName("contract_user_userID_fk_2");

            entity.HasOne(d => d.Partner).WithMany(p => p.ContractPartners)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("contract_user_userID_fk");

            entity.HasOne(d => d.Request).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("contract_request_requestID_fk");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PRIMARY");

            entity.ToTable("news");

            entity.HasIndex(e => e.AdminId, "news_user_userID_fk");

            entity.Property(e => e.NewsId).HasColumnName("newsID");
            entity.Property(e => e.AdminId).HasColumnName("adminID");
            entity.Property(e => e.NewsPublichDate).HasColumnName("News_publich_date");
            entity.Property(e => e.NewsPublisher)
                .HasMaxLength(100)
                .HasColumnName("News_publisher");
            entity.Property(e => e.NewsText)
                .HasMaxLength(500)
                .HasColumnName("News_text");
            entity.Property(e => e.NewsTitle)
                .HasMaxLength(100)
                .HasColumnName("News_title");
            entity.Property(e => e.NewsUpdateDate).HasColumnName("News_update_date");

            entity.HasOne(d => d.Admin).WithMany(p => p.News)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("news_user_userID_fk");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("request");

            entity.HasIndex(e => e.PartnerId, "request_user_userID_fk");

            entity.HasIndex(e => e.UserId, "request_user_userID_fk_2");

            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.AdditionalInformation)
                .HasMaxLength(255)
                .HasColumnName("additional_information");
            entity.Property(e => e.CodeRefinement)
                .HasColumnType("bit(1)")
                .HasColumnName("code_refinement");
            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
            entity.Property(e => e.DeadlineCompletionWork).HasColumnName("deadline_completion_work");
            entity.Property(e => e.Eiscode)
                .HasMaxLength(50)
                .HasColumnName("eiscode");
            entity.Property(e => e.LimitsForRequestPrice).HasColumnName("limits_for_request_price");
            entity.Property(e => e.NmckPrice).HasColumnName("nmck_price");
            entity.Property(e => e.OkpdTwoCode).HasColumnName("okpd_two_code");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.PositionPlanChart)
                .HasMaxLength(50)
                .HasColumnName("position_plan_chart");
            entity.Property(e => e.PreparationDraftCalculationNmcc)
                .HasColumnType("bit(1)")
                .HasColumnName("preparation_draft_calculation_nmcc");
            entity.Property(e => e.PreparationDraftContract)
                .HasColumnType("bit(1)")
                .HasColumnName("preparation_draft_contract");
            entity.Property(e => e.PreparationDraftNotification)
                .HasColumnType("bit(1)")
                .HasColumnName("preparation_draft_notification");
            entity.Property(e => e.PreparationPublicationNotification)
                .HasColumnType("bit(1)")
                .HasColumnName("preparation_publication_notification");
            entity.Property(e => e.PreparingDraftLetter)
                .HasColumnType("bit(1)")
                .HasColumnName("preparing_draft_letter");
            entity.Property(e => e.PreparingObjectDescription)
                .HasColumnType("bit(1)")
                .HasColumnName("preparing_object_description");
            entity.Property(e => e.ProvisionOfContract).HasColumnName("provision_of_contract");
            entity.Property(e => e.ProvisionOfRequest).HasColumnName("provision_of_request");
            entity.Property(e => e.RequestClosingDate).HasColumnName("request_closing_date");
            entity.Property(e => e.RequestCreationDate).HasColumnName("request_creation_date");
            entity.Property(e => e.RequestStatus)
                .HasMaxLength(50)
                .HasColumnName("request_status");
            entity.Property(e => e.StuffName)
                .HasMaxLength(255)
                .HasColumnName("stuff_Name");
            entity.Property(e => e.StuffType)
                .HasMaxLength(50)
                .HasColumnName("stuff_type");
            entity.Property(e => e.SupplierStatus)
                .HasMaxLength(50)
                .HasColumnName("supplier_status");
            entity.Property(e => e.TermOfContract).HasColumnName("term_of_contract");
            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("userName");

            entity.HasOne(d => d.Partner).WithMany(p => p.RequestPartners)
                .HasForeignKey(d => d.PartnerId)
                .HasConstraintName("request_user_userID_fk");

            entity.HasOne(d => d.User).WithMany(p => p.RequestUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("request_user_userID_fk_2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.RoleAccess)
                .HasMaxLength(45)
                .HasColumnName("roleAccess");
            entity.Property(e => e.RoleName)
                .HasMaxLength(40)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<Taskforrequest>(entity =>
        {
            entity.HasKey(e => e.TaskCode).HasName("PRIMARY");

            entity.ToTable("taskforrequest");

            entity.HasIndex(e => e.RequestId, "taskforrequest_request_requestID_fk");

            entity.HasIndex(e => e.IdPartner, "taskforrequest_user_userID_fk");

            entity.Property(e => e.TaskCode)
                .ValueGeneratedNever()
                .HasColumnName("taskCode");
            entity.Property(e => e.DateOfReceipt).HasColumnName("dateOfReceipt");
            entity.Property(e => e.IdPartner).HasColumnName("idPartner");
            entity.Property(e => e.OrganizationCode).HasColumnName("organizationCode");
            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.TaskDeadline)
                .HasMaxLength(45)
                .HasColumnName("taskDeadline");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(45)
                .HasColumnName("taskStatus");

            entity.HasOne(d => d.IdPartnerNavigation).WithMany(p => p.Taskforrequests)
                .HasForeignKey(d => d.IdPartner)
                .HasConstraintName("taskforrequest_user_userID_fk");

            entity.HasOne(d => d.Request).WithMany(p => p.Taskforrequests)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("taskforrequest_request_requestID_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.Email, "Email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.RequestId, "user_request_requestID_fk");

            entity.HasIndex(e => e.Role, "user_roles_roleID_fk");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UserInfo)
                .HasMaxLength(255)
                .HasColumnName("user_info");
            entity.Property(e => e.UserInn)
                .HasMaxLength(12)
                .HasColumnName("UserINN");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserOrgName)
                .HasMaxLength(50)
                .HasColumnName("user_org_name");
            entity.Property(e => e.UserProfile)
                .HasMaxLength(50)
                .HasColumnName("user_profile");
            entity.Property(e => e.UserStatus)
                .HasMaxLength(50)
                .HasColumnName("user_status");

            entity.HasOne(d => d.Request).WithMany(p => p.Users)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("user_request_requestID_fk");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("user_roles_roleID_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
