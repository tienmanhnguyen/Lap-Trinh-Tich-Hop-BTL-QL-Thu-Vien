﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clients_ThuVien.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ServiceQLThuVienSoap")]
    public interface ServiceQLThuVienSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachNXB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachNXB();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachNXB", ReplyAction="*")]
        System.Threading.Tasks.Task<string> LayDanhSachNXBAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ThemNXB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ThemNXB(string ten, string diaChi, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ThemNXB", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ThemNXBAsync(string ten, string diaChi, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SuaNXB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SuaNXB(int id, string ten, string diaChi, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SuaNXB", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SuaNXBAsync(int id, string ten, string diaChi, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/XoaNXB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string XoaNXB(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/XoaNXB", ReplyAction="*")]
        System.Threading.Tasks.Task<string> XoaNXBAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TimKiemNXB", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string TimKiemNXB(string timkiem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TimKiemNXB", ReplyAction="*")]
        System.Threading.Tasks.Task<string> TimKiemNXBAsync(string timkiem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachTacGia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LayDanhSachTacGia();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/LayDanhSachTacGia", ReplyAction="*")]
        System.Threading.Tasks.Task<string> LayDanhSachTacGiaAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ThemTG", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string ThemTG(string ten, string vaitro, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ThemTG", ReplyAction="*")]
        System.Threading.Tasks.Task<string> ThemTGAsync(string ten, string vaitro, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SuaTG", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SuaTG(int id, string ten, string vaitro, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SuaTG", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SuaTGAsync(int id, string ten, string vaitro, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/XoaTG", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string XoaTG(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/XoaTG", ReplyAction="*")]
        System.Threading.Tasks.Task<string> XoaTGAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TimKiemTG", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string TimKiemTG(string timkiem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TimKiemTG", ReplyAction="*")]
        System.Threading.Tasks.Task<string> TimKiemTGAsync(string timkiem);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PhieuMuon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string PhieuMuon(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/PhieuMuon", ReplyAction="*")]
        System.Threading.Tasks.Task<string> PhieuMuonAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TinhTrangMuon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string TinhTrangMuon(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TinhTrangMuon", ReplyAction="*")]
        System.Threading.Tasks.Task<string> TinhTrangMuonAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceQLThuVienSoapChannel : Clients_ThuVien.ServiceReference.ServiceQLThuVienSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceQLThuVienSoapClient : System.ServiceModel.ClientBase<Clients_ThuVien.ServiceReference.ServiceQLThuVienSoap>, Clients_ThuVien.ServiceReference.ServiceQLThuVienSoap {
        
        public ServiceQLThuVienSoapClient() {
        }
        
        public ServiceQLThuVienSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceQLThuVienSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceQLThuVienSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceQLThuVienSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string LayDanhSachNXB() {
            return base.Channel.LayDanhSachNXB();
        }
        
        public System.Threading.Tasks.Task<string> LayDanhSachNXBAsync() {
            return base.Channel.LayDanhSachNXBAsync();
        }
        
        public string ThemNXB(string ten, string diaChi, string email) {
            return base.Channel.ThemNXB(ten, diaChi, email);
        }
        
        public System.Threading.Tasks.Task<string> ThemNXBAsync(string ten, string diaChi, string email) {
            return base.Channel.ThemNXBAsync(ten, diaChi, email);
        }
        
        public string SuaNXB(int id, string ten, string diaChi, string email) {
            return base.Channel.SuaNXB(id, ten, diaChi, email);
        }
        
        public System.Threading.Tasks.Task<string> SuaNXBAsync(int id, string ten, string diaChi, string email) {
            return base.Channel.SuaNXBAsync(id, ten, diaChi, email);
        }
        
        public string XoaNXB(int id) {
            return base.Channel.XoaNXB(id);
        }
        
        public System.Threading.Tasks.Task<string> XoaNXBAsync(int id) {
            return base.Channel.XoaNXBAsync(id);
        }
        
        public string TimKiemNXB(string timkiem) {
            return base.Channel.TimKiemNXB(timkiem);
        }
        
        public System.Threading.Tasks.Task<string> TimKiemNXBAsync(string timkiem) {
            return base.Channel.TimKiemNXBAsync(timkiem);
        }
        
        public string LayDanhSachTacGia() {
            return base.Channel.LayDanhSachTacGia();
        }
        
        public System.Threading.Tasks.Task<string> LayDanhSachTacGiaAsync() {
            return base.Channel.LayDanhSachTacGiaAsync();
        }
        
        public string ThemTG(string ten, string vaitro, string email) {
            return base.Channel.ThemTG(ten, vaitro, email);
        }
        
        public System.Threading.Tasks.Task<string> ThemTGAsync(string ten, string vaitro, string email) {
            return base.Channel.ThemTGAsync(ten, vaitro, email);
        }
        
        public string SuaTG(int id, string ten, string vaitro, string email) {
            return base.Channel.SuaTG(id, ten, vaitro, email);
        }
        
        public System.Threading.Tasks.Task<string> SuaTGAsync(int id, string ten, string vaitro, string email) {
            return base.Channel.SuaTGAsync(id, ten, vaitro, email);
        }
        
        public string XoaTG(int id) {
            return base.Channel.XoaTG(id);
        }
        
        public System.Threading.Tasks.Task<string> XoaTGAsync(int id) {
            return base.Channel.XoaTGAsync(id);
        }
        
        public string TimKiemTG(string timkiem) {
            return base.Channel.TimKiemTG(timkiem);
        }
        
        public System.Threading.Tasks.Task<string> TimKiemTGAsync(string timkiem) {
            return base.Channel.TimKiemTGAsync(timkiem);
        }
        
        public string PhieuMuon(string id) {
            return base.Channel.PhieuMuon(id);
        }
        
        public System.Threading.Tasks.Task<string> PhieuMuonAsync(string id) {
            return base.Channel.PhieuMuonAsync(id);
        }
        
        public string TinhTrangMuon(string id) {
            return base.Channel.TinhTrangMuon(id);
        }
        
        public System.Threading.Tasks.Task<string> TinhTrangMuonAsync(string id) {
            return base.Channel.TinhTrangMuonAsync(id);
        }
    }
}