package com.example.cinetec.customviews;
import android.content.Context;
import android.content.res.TypedArray;
import android.util.AttributeSet;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.widget.AppCompatImageView;

import com.example.cinetec.R;

public class AspectRatioImageView extends AppCompatImageView {
    private float ratio=1f;
    public float getRatio() {
        return ratio;
    }

    public void setRatio(float ratio) {
        this.ratio = ratio;
    }


    public AspectRatioImageView(@NonNull Context context) {
        super(context);

    }

    public AspectRatioImageView(@NonNull Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        TypedArray a=context.obtainStyledAttributes(attrs, R.styleable.AspectRatioImageView);
        ratio=a.getFloat(R.styleable.AspectRatioImageView_ratio,1f);
        a.recycle();
    }

    public AspectRatioImageView(@NonNull Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        TypedArray a=context.obtainStyledAttributes(attrs, R.styleable.AspectRatioImageView);
        ratio=a.getFloat(R.styleable.AspectRatioImageView_ratio,1f);
        a.recycle();
    }


    @Override
    protected void onMeasure(int widthMeasureSpec, int heightMeasureSpec) {
        super.onMeasure(widthMeasureSpec, heightMeasureSpec);
        int width=widthMeasureSpec;
        int height=heightMeasureSpec;
        if(width==0 && height==0)return;
        if(width>0){
            height=(int)(width*ratio);
        }
        else{
            width=(int)(height/ratio);
        }
        setMeasuredDimension(width,height);

    }
}
