package com.example.cinetec.customviews;

import android.content.Context;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.Nullable;

import com.example.cinetec.R;

public class CinemaSelection extends LinearLayout {
    TextView Cinema_text;
    LinearLayout layout;

    /**
     * Class constructor
     * @param context android context
     */
    public CinemaSelection(Context context) {
        super(context);
        build(context);
    }

    /**
     * class constructor
     * @param context   android context
     * @param attrs view attrs
     */
    public CinemaSelection(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        build(context);
    }

    /**
     * Class constructor
     * @param context   android context
     * @param attrs view attrs
     * @param defStyleAttr  view styles
     */
    public CinemaSelection(Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        build(context);

    }

    /**
     * Class constructor
     * @param context   android context
     * @param attrs view attrs
     * @param defStyleAttr  view styles
     * @param defStyleRes
     */
    public CinemaSelection(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        build(context);

    }

    /**
     * Set the text of the textview
     * @param text String text
     */
    public void set_text(String text){
        this.Cinema_text.setText(text);
    }
    public void build(Context context){
        View view= LayoutInflater.from(context).inflate(R.layout.view_cinema_selection,this);
        Cinema_text=(TextView) view.findViewById(R.id.branch_text);
        layout=(LinearLayout) view.findViewById(R.id.view_cinema_selection_linear);


    }

    /**
     * Method called when the view its clicked
     * @param l click listener
     */
    @Override
    public void setOnClickListener(@Nullable OnClickListener l) {
        super.setOnClickListener(l);
        layout.setOnClickListener(l);
    }

}
