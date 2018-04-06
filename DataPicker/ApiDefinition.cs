using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace DataPicker
{
    [BaseType(typeof(UIView))]
    public interface LZPickerView
    {
        // @property (nonatomic, weak) UIButton * cancelBtn __attribute__((iboutlet));
        [Export("cancelBtn", ArgumentSemantic.Weak)]
        UIButton CancelBtn { get; set; }

        // @property (nonatomic, weak) UIButton * sureBtn __attribute__((iboutlet));
        [Export("sureBtn", ArgumentSemantic.Weak)]
        UIButton SureBtn { get; set; }

        // @property (nonatomic, weak) UILabel * titleLB __attribute__((iboutlet));
        [Export("titleLB", ArgumentSemantic.Weak)]
        UILabel TitleLB { get; set; }

        // @property (nonatomic, weak) UIPickerView * lzPickerView __attribute__((iboutlet));
        [Export("lzPickerView", ArgumentSemantic.Weak)]
        UIPickerView LzPickerView { get; set; }

        // @property (nonatomic, weak) UIView * bgVIew __attribute__((iboutlet));
        [Export("bgVIew", ArgumentSemantic.Weak)]
        UIView BgVIew { get; set; }

        // @property (nonatomic, weak) UIView * toolBgView __attribute__((iboutlet));
        [Export("toolBgView", ArgumentSemantic.Weak)]
        UIView ToolBgView { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * pickerHeight __attribute__((iboutlet));
        [Export("pickerHeight", ArgumentSemantic.Weak)]
        NSLayoutConstraint PickerHeight { get; set; }

        // @property (nonatomic, weak) NSLayoutConstraint * bgViewHeight __attribute__((iboutlet));
        [Export("bgViewHeight", ArgumentSemantic.Weak)]
        NSLayoutConstraint BgViewHeight { get; set; }

        // @property (nonatomic, strong) NSArray * dataSource;
        [Export("dataSource", ArgumentSemantic.Strong)]
        //[Verify(StronglyTypedNSArray)]
        NSArray DataSource { get; set; }

        // @property (copy, nonatomic) NSString * selectDefault;
        [Export("selectDefault")]
        string SelectDefault { get; set; }

        // @property (copy, nonatomic) void (^selectValue)(NSString *);
        [Export("selectValue", ArgumentSemantic.Copy)]
        Action<NSString> SelectValue { get; set; }

        // @property (copy, nonatomic) NSString * titleText;
        [Export("titleText")]
        string TitleText { get; set; }

        // -(void)show;
        [Export("show")]
        void Show();

        // -(void)lzPickerVIewType:(LZPickerViewType)type;
        [Export("lzPickerVIewType:")]
        void LzPickerVIewType(LZPickerViewType type);
    }
}

